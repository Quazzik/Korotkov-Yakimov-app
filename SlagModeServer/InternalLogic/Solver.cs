using SlagModeServer.DTOs;
using SlagModeServer.enums;
using SlagSolverLibrary;
using System.Data;
using UBFBaseLibrary.Models;
using UBFCalculationLibrary;

namespace SlagModeServer.InternalLogic
{
    public static class Solver
    {
        public static TabeOutputData GetTableData(InputKal slagModeModel) //Здесь происходит ошибка при расчетах с данными из БД
        {
            #region SlagModeData
            var totalAgglomerate = 0d;
            var totalMaterials = 0d;
            foreach (var material in slagModeModel.Components)
            {
                if (material.Sourcename == nameof(MaterialTypes.Agglomerate23) || material.Sourcename == nameof(MaterialTypes.Agglomerate4))
                    totalAgglomerate += material.Consumption;
                totalMaterials += material.Consumption;
            }

            var calcModel = new SlagMode();
            calcModel.BaseChugun = new UBFBaseLibrary.UBF_Chugun
            {
                Si = slagModeModel.Iron.Si,
                S = slagModeModel.Iron.S,
                Mn = slagModeModel.Iron.Mn,
                C = slagModeModel.Iron.C,
                Ti = slagModeModel.Iron.Ti,
                Cr = slagModeModel.Iron.Cr
            };
            calcModel.BaseSlag = new UBFBaseLibrary.UBF_Slag
            {
                /*
                CaO = slagModeModel.SlagParameters.CaO,
                SiO2 = slagModeModel.SlagParameters.SiO2,
                TiO2 = slagModeModel.SlagParameters.TiO2
                */

                CaO = slagModeModel.Slag.CaO,
                SiO2 = slagModeModel.Slag.SiO2,
                TiO2 = slagModeModel.Slag.TiO2
            };
            calcModel.BaseKoks = new UBFBaseLibrary.UBF_KoksComponent
            {
                /*
                Rashod = slagModeModel.CokeParameters.Consumption,
                Sera = slagModeModel.CokeParameters.Sulfur,
                Zola = slagModeModel.CokeParameters.AshAmount,
                ZolaCaO = slagModeModel.CokeParameters.AshCaOFraction,
                ZolaSiO2 = slagModeModel.CokeParameters.AshSiO2Fraction,
                ZolaAl2O3 = slagModeModel.CokeParameters.AshAl2O3Fraction,
                ZolaMgO = slagModeModel.CokeParameters.AshMgOFraction,
                */
                Rashod = slagModeModel.Coke.Consumption,
                Sera = slagModeModel.Coke.Sulfur,
                Zola = slagModeModel.Coke.AshAmount,
                ZolaCaO = slagModeModel.Coke.AshCaOFraction,
                ZolaSiO2 = slagModeModel.Coke.AshSiO2Fraction,
                ZolaAl2O3 = slagModeModel.Coke.AshAl2O3Fraction,
                ZolaMgO = slagModeModel.Coke.AshMgOFraction
            };

            foreach (var component in slagModeModel.Components)
            {
                calcModel.BaseShihta.Add(new UBFBaseLibrary.UBF_ShihtaComponent
                {
                    Name = component.Sourcename,
                    Rashod = component.Consumption,
                    Fe = component.Fe,
                    SiO2 = component.SiO2,
                    Al2O3 = component.Al2O3,
                    CaO = component.CaO,
                    MgO = component.MgO,
                    S = component.S,
                    MnO = component.MnO,
                    TiO2 = component.TiO2,
                });
            }
            calcModel.SetPartOfZhRM(calcModel.BaseShihta);

            var data = new TabeOutputData
            {
                slagBasicity1 = calcModel.BaseOsnovnost1,
                slagOut = calcModel.MassOfOxSlagSum,
                materialCons = calcModel.RashodRudMat,
                totalAglo = totalAgglomerate,
                totalMat = totalMaterials
            };

            foreach (var material in slagModeModel.Components)
            {
                switch (material.Sourcename)
                {
                    case nameof(MaterialTypes.Agglomerate23): data.propAglo23 = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.Agglomerate4): data.propAglo4 = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.Ssgpo): data.propSsgpo = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.Lebedinskiy): data.propLeb = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.Kachkanarsiy): data.propKach = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.Mixailovskiy): data.propMix = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.Ore): data.propOre = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.WeldSlag): data.propWeldSlag = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.BlastFurnaceAddiction): data.propBFAddict = material.Consumption / totalMaterials; break;
                    case nameof(MaterialTypes.MinimalIncludes): data.propMinInclude = material.Consumption / totalMaterials; break;
                }
            }
            #endregion

            #region SlagSolverData

            calcModel.BaseChugun.Temp = calcModel.BaseChugun.Temp == 0 ? 1450 : calcModel.BaseChugun.Temp;

            var solver = new SlagSolver();
            //var solverData = solver.Solve(slagModeModel.SlagParameters.CaO, slagModeModel.SlagParameters.SiO2, slagModeModel.SlagParameters.Al2O3, slagModeModel.SlagParameters.MgO);
            var solverData = solver.Solve(slagModeModel.Slag.CaO, slagModeModel.Slag.SiO2, slagModeModel.Slag.Al2O3, slagModeModel.Slag.MgO);
            data.CaOBalSlagMass = calcModel.UdWeight;
            data.BalSlagMass = calcModel.MassOfOxSlagSum;
            data.slagBasicity2 = solverData.Osnovnost2;
            data.slagBasicity3 = solverData.Osnovnost3;
            data.slagBasicityKulikov = solverData.OsnovnostKulikov;
            data.SlagTemperature = UBF_Functions.GetSlagTemparature(calcModel.BaseChugun);
            data.slagTemperature_25puaz = solverData.Temp_25_puaz;
            data.CurrSlagViscosity = UBF_Functions.GetSlagViscosityByTemp(solverData.K_b, solverData.K_a, data.SlagTemperature);
            data.Viscosity_1400 = solverData.Viscosity_1400;
            data.Viscosity_1450 = solverData.Viscosity_1450;
            data.Viscosity_1500 = solverData.Viscosity_1500;
            data.Viscosity_1550 = solverData.Viscosity_1550;
            data.TotalSInOre = calcModel.GetTotalRuda_S;
            data.SActivity = calcModel.GetActivity_S;
            data.SDistribution = calcModel.LS_Fact;
            data.SContentInCastIron = calcModel.BaseChugun.S;
            data.Temp_7_puaz = solverData.Temp_7_puaz;
            data.Gradient_7_25 = solverData.Gradient_7_25;
            data.Gradient_1400_1500 = solverData.Gradient_1400_1500;
            data.CastIronTemp = slagModeModel.Iron.Temp; //Не уверен что это нужно выводить, это же чистые входные данные
            #endregion
            return data;
        }
    }
}