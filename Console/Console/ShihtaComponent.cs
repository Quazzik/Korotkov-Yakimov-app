using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Console
{
    public class ShihtaComponent
    {
        #region Osnova
        [JsonIgnore]
        public Shihta Shihta { get; set; } = new(new ());
        public string Name {  get; set; }
        public double Weight {  get; set; }
        public double Wet { get; set; }
        public double PMPP { get; set; }
        [JsonIgnore]
        public double CorrectionPartOfWet => Weight * (100 - Wet) / 100;
        [JsonIgnore]
        public double PartOfDry => CorrectionPartOfWet / Shihta.TotalPartOfWet;
        [JsonIgnore]
        public double CorrectionPartOfPMPP => PartOfDry * (100 - PMPP) / 100;
        [JsonIgnore]
        public double PartOfPMPP => CorrectionPartOfPMPP / Shihta.TotalPartOfPMPP;
        [JsonIgnore]
        public double PercentOfPMPP => PartOfDry * PMPP;

        #endregion

        #region Chemical Components
        public double Fe {  get; set; }
        public double FeO { get; set; }
        public double CaO { get; set; }
        public double SiO2 { get; set; }
        public double MgO { get; set; }
        public double Al2O3 { get; set; }
        public double TiO2 { get; set; }
        public double S { get; set; }
        public double P { get; set; }
        public double Cr { get; set; }
        public double Zn { get; set; }
        public double MnO { get; set; }

        #endregion

        #region Chemical Components Mass
        [JsonIgnore]
        public double FeMass => Fe * PartOfDry;
        [JsonIgnore]
        public double FeOMass => FeO * PartOfDry;
        [JsonIgnore]
        public double CaOMass => CaO * PartOfDry;
        [JsonIgnore]
        public double SiO2Mass => SiO2 * PartOfDry;
        [JsonIgnore]
        public double MgOMass => MgO * PartOfDry;
        [JsonIgnore]
        public double Al2O3Mass => Al2O3 * PartOfDry;
        [JsonIgnore]
        public double TiO2Mass => TiO2 * PartOfDry;
        [JsonIgnore]
        public double SMass => S * PartOfDry;
        [JsonIgnore]
        public double PMass => P * PartOfDry;
        [JsonIgnore]
        public double CrMass => Cr * PartOfDry;
        [JsonIgnore]
        public double ZnMass => Zn * PartOfDry;
        [JsonIgnore]
        public double MnOMass => MnO * PartOfDry;

        #endregion
    }
}
