using Microsoft.EntityFrameworkCore;
using SlagModeServer.DTOs;
using SlagModeServer.entities.NewStructure;
namespace SlagModeServer.Services
{
    public class SlagModeService(SlagSolverDbContext _dbContext)
    {
        public async Task<List<ShihtaCatalog>> GetMaterialsAsync()
        {
            var result = await _dbContext.ChargeCatalogs.ToListAsync();
            return result;
        }

        public async Task<List<BlastFurnaces>> GetBlastFurnacesAsync()
        {
            var result = await _dbContext.BlastFurnaces.ToListAsync();
            return result;
        }

        public async Task<OldParametersDTO?> GetOldInputsAsync(int variantId)
        {
            var inputData = await _dbContext.VariantsParameters
                .Include(x => x.User)
                .Include(x => x.BlastFurnace)
                .FirstOrDefaultAsync(x => x.VariantID == variantId);

            if (inputData == null)
                return null;

            return GetInput(inputData).ToBlockingEnumerable().ElementAt(0);
        }

        private async IAsyncEnumerable<OldParametersDTO?> GetInput(params VariantsParameter[] inputDatas)
        {
            foreach (var inputData in inputDatas)
            {
                var components = await _dbContext.VariantCharges.Include(x => x.CatalogElem).ToListAsync();

                var chargeslist = new List<ChargesDTO>();

                foreach (var comp in components)
                {
                    if (comp.VariantID == inputData.VariantID)
                    {
                        chargeslist.Add(new ChargesDTO
                        {
                            Sourcename = comp.CatalogElem.NameShihta,
                            Consumption = comp.Consumption,
                            Fe = comp.ShihtaFe,
                            SiO2 = comp.ShihtaSiO2,
                            Al2O3 = comp.ShihtaAl2O3,
                            CaO = comp.ShihtaCaO,
                            MgO = comp.ShihtaMgO,
                            S = comp.ShihtaS,
                            MnO = comp.ShihtaMnO,
                            TiO2 = comp.ShihtaTiO2,
                            RuSourceName = comp.CatalogElem.RuNameShihta ?? "Неизвестный материал",
                        });
                    }
                }

                yield return new OldParametersDTO
                {
                    Id = inputData.VariantID,
                    Username = inputData.User?.Login ?? "Неизвестный пользователь",
                    DateVariant = inputData.DateVariant,
                    VariantName = inputData.VariantName ?? "Безымянный",
                    BFName = inputData.BlastFurnace?.Name ?? "Неизвестная доменная печь",
                    Iron = new InputCastIronForCalc
                    {
                        Si = inputData.IronSi,
                        S = inputData.IronS,
                        Mn = inputData.IronMn,
                        C = inputData.IronC,
                        Ti = inputData.IronTi,
                        Temp = inputData.IronTemperature
                    },
                    Slag = new InputSlagForCalc
                    {
                        CaO = inputData.SlagCaO,
                        SiO2 = inputData.SlagSiO2,
                        TiO2 = inputData.SlagTiO2,
                        Al2O3 = inputData.SlagAl2O3,
                        MgO = inputData.SlagMgO
                    },
                    Coke = new InputCokeForCalcs
                    {
                        Consumption = inputData.CokeConsumption,
                        Sulfur = inputData.CokeS,
                        AshAmount = inputData.CokeAsh,
                        AshCaOFraction = inputData.CokeAshCaO,
                        AshSiO2Fraction = inputData.CokeAshSiO2,
                        AshAl2O3Fraction = inputData.CokeAshAl2O3,
                        AshMgOFraction = inputData.CokeAshMgO,
                    },
                    Components = chargeslist
                };
            }
        }

        public async Task<bool> EditGuideAsync(ShihtaCatalog material)
        {
            var dataToEdit = await _dbContext.ChargeCatalogs.FirstOrDefaultAsync(x => x.ComponentID == material.ComponentID);
            if (dataToEdit != null)
            {
                _dbContext.Entry(dataToEdit).CurrentValues.SetValues(material);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //Метод changeInputAsync должен принимать 2 параметра: [FromQuery] int calcID, [FromBody] модель варианта
        public async Task<bool> AddInputAsync(CalcDTO data)
        {
            data.parameters.DateVariant = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
            try
            {
                await _dbContext.VariantsParameters.AddAsync(data.parameters); //Юра, ты молодец, и Женя тебе верит
                await _dbContext.SaveChangesAsync(); //Женя, не трогай! Если это убрать, то у Charges не будет VariantID и сервак кинет ошибку из-за которой ты собирался новые DTO создавать
                var currCalcID = data.parameters.VariantID; //Нужно задать ключ для Charges, чтобы его задать его нужно достать из БД, потому что EFCore е хочет доставать (видимо не видит связи (логически её тут и нет))
                foreach (var charge in data.Charges)
                {
                    charge.VariantID = currCalcID;
                    await _dbContext.VariantCharges.AddAsync(charge);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteOldInputAsync(int calcID)
        {
            try
            {
                await _dbContext.VariantsParameters.Where(x => x.VariantID == calcID).ExecuteDeleteAsync();

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<OldParametersDTO?>> GetUserInputsAsync(int userID)
        {
            var inputData = await _dbContext.VariantsParameters
               .Include(x => x.User)
               .Include(x => x.BlastFurnace)
               .OrderBy(x => x.DateVariant)
               .Where(x => x.UserID == userID).ToListAsync();

            if (inputData == null)
                return [];

            return GetInput([..inputData]).ToBlockingEnumerable().ToList();
        }
    }
}
