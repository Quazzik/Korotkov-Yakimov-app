using System.Linq;
using AutoMapper;
using Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppi.Entities;
using WebAppi.Models;

namespace WebAppi.Sevices
{
    public class AglomCalcService (SuperDBContext superDBContext, IMapper mapper)
    {
       public async Task<SostavAglom> CalcAglom (InputDTO input)
       {
            if(input.CreatePreset)
                await CreatePreset(input);
            var sostavOfAglom = new SostavAglom(input.StartEnter, input.END);
            return sostavOfAglom;
       } 

       public async Task CreatePreset(InputDTO input)
       {
            var zolaOfCocksick = mapper.Map<ZolaOfCocsickDB>(input.ZolaOfCocksick);
            var fluxAddition = mapper.Map<FluxAdditionsDB>(input.FluxAdditions);
            var cocksick = mapper.Map<CocksickDB>(input.Cocksick);
            var startEnter = mapper.Map<StartEnterDB>(input.StartEnter);

            await superDBContext.ZolaOfCocsicks.AddAsync(zolaOfCocksick);
            await superDBContext.FluxAdditions.AddAsync(fluxAddition);
            await superDBContext.Cocsicks.AddAsync(cocksick);
            await superDBContext.StartEnters.AddAsync(startEnter);
            await superDBContext.SaveChangesAsync();

            var preset = new DefaultPreset()
            {
                UserId = input.UserId,
                ZolaOfCocsickId = zolaOfCocksick.Id,
                FluxAdditionsId = fluxAddition.Id,
                CocksickId = cocksick.Id,
                StartEnterId = startEnter.Id,
                CreatedAt = DateTime.UtcNow,
            };
            await superDBContext.DefaultPresets.AddAsync(preset);
            await superDBContext.SaveChangesAsync();

            var shihtaComponents = input.ShihtaComponents.Select(mapper.Map<ShihtaComponentsDB>).ToList();

            foreach (var shihtaComponent in shihtaComponents)
                shihtaComponent.PresetId = preset.Id;

            await superDBContext.ShihtaComponents.AddRangeAsync(shihtaComponents);
            await superDBContext.SaveChangesAsync();
        }

        public async Task<List<DefaultPreset>> GetHistory(int id)
        {
            return await superDBContext.DefaultPresets
                .Include(x => x.StartEnter)
                .Where(x => x.UserId == id)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<DefaultPreset> UseDefaultPreset(int id)
        {
            return await superDBContext.DefaultPresets
                .Include(x => x.ZolaOfCocksick)
                .Include(x => x.Cocksick)
                .Include(x => x.ShihtaComponents)
                .Include(x => x.StartEnter)
                .Include(x => x.FluxAdditions)
                .FirstOrDefaultAsync(x => x.UserId == id);
        }
        public async Task<DefaultPreset> GetPreset(int id)
        {
            return await superDBContext.DefaultPresets
                .Include(x => x.ZolaOfCocksick)
                .Include(x => x.Cocksick)
                .Include(x => x.ShihtaComponents)
                .Include(x => x.StartEnter)
                .Include(x => x.FluxAdditions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<JsonResult> DeletePreset(int id)
        {
            var preset = await superDBContext.DefaultPresets.FirstOrDefaultAsync(x => x.Id == id);
            if (preset == null) 
            {
                return new(new
                {
                    Message = "Не существует такого пресета"
                });
            }
            superDBContext.DefaultPresets.Remove(preset);
            await superDBContext.SaveChangesAsync();
            return new(new
            {
                message = "Пресет успешно удален"
            });
        }
    }
        
}
