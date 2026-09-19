using Console;
using System.Text.Json.Serialization;

namespace WebAppi.Models
{
    public class InputDTO
    {
        public int UserId { get; set; }
        public ZolaOfCocksick ZolaOfCocksick { get; set; }
        public Cocksick Cocksick { get; set; }
        public FluxAdditions FluxAdditions { get; set; }
        //public MmkCoef MmkCoef { get; set; }
        public List<ShihtaComponent> ShihtaComponents { get; set; }
        public StartEnter StartEnter { get; set; }
        [JsonIgnore]
        public Shihta Shihta => new Shihta(ShihtaComponents);
        [JsonIgnore]
        public List<END> END => GenEnds();

        public bool CreatePreset { get; set; }

        private List<END> GenEnds()
        {
            ShihtaComponents.ForEach(x => x.Shihta = Shihta);

            return [
            new END
            {
                ReportComponentOfShihta = CalcLES.ConsimtionJRM,
                ReportPercentOfFe = Shihta.TotalFeMass,
                ReportPercentOfS = Shihta.TotalSMass,
                ReportPercentOfP = Shihta.TotalPMass,
                ReportPercentOfFeO = Shihta.TotalFeOMass,
                ReportPercentOfCaO = Shihta.TotalCaOMass,
                ReportPercentOfSiO2 = Shihta.TotalSiO2Mass,
                ReportPercentOfAl2O3 = Shihta.TotalAl2O3Mass,
                ReportPercentOfMgO = Shihta.TotalMgOMass,
                ReportPercentOfMnO = Shihta.TotalMnOMass,
                ReportPercentOfTiO2 = Shihta.TotalTiO2Mass,
                ReportPercentOfZn = Shihta.TotalZnMass,
                ReportPercentOfPMPP = Shihta.TotalPercentOfPMPP
            },

            new END
            {
                ReportComponentOfShihta = CalcLES.ConsimitionIzvestyak,
                ReportPercentOfFe = 0,
                ReportPercentOfS = 0,
                ReportPercentOfP = 0,
                ReportPercentOfFeO = 0,
                ReportPercentOfCaO = FluxAdditions.IzvestnyakCaO,
                ReportPercentOfSiO2 = FluxAdditions.IzvestnyakSiO2,
                ReportPercentOfAl2O3 = FluxAdditions.IzvestnyakAl2O3,
                ReportPercentOfMgO = FluxAdditions.IzvestnyakMgO,
                ReportPercentOfMnO = 0,
                ReportPercentOfTiO2 = 0,
                ReportPercentOfZn = 0,
                ReportPercentOfPMPP = FluxAdditions.IzvestnyakPMPP
            },

            new END
            {
                ReportComponentOfShihta = StartEnter.DolomyteInAgl,
                ReportPercentOfFe = 0,
                ReportPercentOfS = 0,
                ReportPercentOfP = 0,
                ReportPercentOfFeO = 0,
                ReportPercentOfCaO = FluxAdditions.DolomyteCaO,
                ReportPercentOfSiO2 = FluxAdditions.DolomyteSiO2,
                ReportPercentOfAl2O3 = FluxAdditions.DolomyteAl2O3,
                ReportPercentOfMgO = FluxAdditions.DolomyteMgO,
                ReportPercentOfMnO = 0,
                ReportPercentOfTiO2 = 0,
                ReportPercentOfZn = 0,
                ReportPercentOfPMPP = FluxAdditions.DolomytePMPP
            },

            new END
            {
                ReportComponentOfShihta = Cocksick.Weight,
                ReportPercentOfFe = 0,
                ReportPercentOfS = Cocksick.PercentSera,
                ReportPercentOfP = 0,
                ReportPercentOfFeO = 0,
                ReportPercentOfCaO = 0,
                ReportPercentOfSiO2 = 0,
                ReportPercentOfAl2O3 = 0,
                ReportPercentOfMgO = 0,
                ReportPercentOfMnO = 0,
                ReportPercentOfTiO2 = 0,
                ReportPercentOfZn = 0,
                ReportPercentOfPMPP = 0
            },

            new END
            {
                ReportComponentOfShihta = Cocksick.Weight * Cocksick.PercentZola / 100,
                ReportPercentOfFe = ZolaOfCocksick.Fe,
                ReportPercentOfS = 0,
                ReportPercentOfP = ZolaOfCocksick.P,
                ReportPercentOfFeO = 0,
                ReportPercentOfCaO = ZolaOfCocksick.CaO,
                ReportPercentOfSiO2 = ZolaOfCocksick.SiO2,
                ReportPercentOfAl2O3 = ZolaOfCocksick.Al2O3,
                ReportPercentOfMgO = ZolaOfCocksick.MgO,
                ReportPercentOfMnO = 0,
                ReportPercentOfTiO2 = 0,
                ReportPercentOfZn = 0,
                ReportPercentOfPMPP = 0

            }
        ];
        }

        [JsonIgnore]
        public CalcLES CalcLES => new CalcLES(Shihta, FluxAdditions, Cocksick, StartEnter, ZolaOfCocksick);
    }
}
