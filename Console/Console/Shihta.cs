using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Console
{
    public class Shihta
    {
        public Shihta(List<ShihtaComponent> components) 
        {
            Components = new();
            if (!components.Any()) return;
            foreach ( var component in components)
                AddComponent(component);
        }
        [JsonIgnore]
        public List<ShihtaComponent> Components { get; set; }
        public double TotalPartOfWet => Components.Sum(x => x.CorrectionPartOfWet);
        public double TotalPartOfPMPP => Components.Sum(x => x.CorrectionPartOfPMPP);
        public double TotalPercentOfPMPP => Components.Sum(x => x.PercentOfPMPP);

        #region Total Chemistry
        public double TotalFeMass => Components.Sum(x => x.FeMass);  
        public double TotalFeOMass => Components.Sum(x => x.FeOMass);
        public double TotalCaOMass => Components.Sum(x => x.CaOMass);
        public double TotalSiO2Mass => Components.Sum(x => x.SiO2Mass);
        public double TotalMgOMass => Components.Sum(x => x.MgOMass);
        public double TotalAl2O3Mass => Components.Sum(x => x.Al2O3Mass);
        public double TotalTiO2Mass => Components.Sum(x => x.TiO2Mass);
        public double TotalSMass => Components.Sum(x => x.SMass);
        public double TotalPMass => Components.Sum(x => x.PMass);
        public double TotalCrMass => Components.Sum(x => x.CrMass);
        public double TotalZnMass => Components.Sum(x => x.ZnMass);
        public double TotalMnOMass => Components.Sum(x => x.MnOMass);

        #endregion

        public void AddComponent (ShihtaComponent component)
        {
            component.Shihta = this;
            Components.Add(component);
        }
    }                 
}
