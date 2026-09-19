using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console.DTO;

namespace Console
{
    public class SostavAglom(StartEnter startEnter,  List<END> components)
    {
        //public List<double> SpecificUsage => [.. Components.Select(x => x.ReportComponentOfShihta), TotalReportShihta];
        //public MmkShihta mmkShihta => new MmkShihta(this,  mmkCoef);
        public List<ComponentInfo> Components => [.. components.Select((x, i) => new ComponentInfo(x, i)),
        new ComponentInfo{
            ComponentName = "Итог",
            ReportComponentOfShihta = Math.Round(TotalReportShihta,3),
            ReportFe = Math.Round(GoesToAglomFe,3),
            ReportS = Math.Round(GoesToAglomS,3),
            ReportP = Math.Round(GoesToAglomP,3),
            ReportFeO = Math.Round(GoesToAglomFeO,3),
            ReportFe2O3 = Math.Round(GoesToAglomFe2O3,3),
            ReportCaO = Math.Round(GoesToAglomCaO,3),
            ReportSiO2 = Math.Round(GoesToAglomSiO2,3),
            ReportAl2O3 = Math.Round(GoesToAglomAl2O3,3),
            ReportMgO = Math.Round(GoesToAglomMgO,3),
            ReportMnO = Math.Round(GoesToAglomMnO,3),
            ReportTiO2 = Math.Round(GoesToAglomTiO2,3),
            ReportZn = Math.Round(GoesToAglomZn,3),
            ReportPMPP = Math.Round(GoesToAglomPMPP,3),
            ReportCaO_SiO2 = Math.Round(CaOSiO2,3),
            ReportOxideSum = Math.Round(TotalGoesToAglom,3)
        }]; 
        private double TotalReportFe => components.Sum(x => x.ReportFe);
        private double TotalReportS => components.Sum(x => x.ReportS) * 0.1;
        private double TotalReportP => components.Sum(x => x.ReportP);
        private double TotalReportFeO => components.Sum(x => x.ReportFeO);
        private double TotalReportCaO => components.Sum(x => x.ReportCaO);
        private double TotalReportSiO2 => components.Sum(x => x.ReportSiO2);
        private double TotalReportAl2O3 => components.Sum(x => x.ReportAl2O3);
        private double TotalReportMgO => components.Sum(x => x.ReportMgO);
        private double TotalReportMnO => components.Sum(x => x.ReportMnO);
        private double TotalReportTiO2 => components.Sum(x => x.ReportTiO2);
        private double TotalReportZn => components.Sum(x => x.ReportZn);
        private double TotalReportPMPP => components.Sum(x => x.ReportPMPP);
        private double TotalReportShihta => components.Sum(x => x.ReportComponentOfShihta);


        private double GoesToAglomFe => TotalReportFe;
        private double GoesToAglomS => TotalReportS;
        private double GoesToAglomP => TotalReportP;
        private double GoesToAglomFeO => startEnter.FeOinAgl;
        private double GoesToAglomFe2O3 => (GoesToAglomFe - 56d / 72d * startEnter.FeOinAgl) * 160d / 112d;
        private double GoesToAglomCaO => TotalReportCaO;
        private double GoesToAglomSiO2 => TotalReportSiO2;
        private double GoesToAglomAl2O3 => TotalReportAl2O3;
        private double GoesToAglomMgO => TotalReportMgO;
        private double GoesToAglomMnO => TotalReportMnO;
        private double GoesToAglomTiO2 => TotalReportTiO2;
        private double GoesToAglomZn => TotalReportZn;
        private double GoesToAglomPMPP => TotalReportPMPP;
        private double TotalGoesToAglom => GoesToAglomS + GoesToAglomP
            + GoesToAglomFeO
            + GoesToAglomFe2O3
            + GoesToAglomCaO
            + GoesToAglomSiO2
            + GoesToAglomAl2O3
            + GoesToAglomMgO
            + GoesToAglomMnO
            + GoesToAglomTiO2
            + GoesToAglomZn;

        private double CaOSiO2 => GoesToAglomCaO / GoesToAglomSiO2;
    } 
}