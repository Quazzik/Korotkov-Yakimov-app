using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UBFBaseLibrary;

namespace SlagModeServer.entities.NewStructure
{
    [PrimaryKey(nameof(ComponentID))]
    public class ShihtaCatalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComponentID { get; set; }

        public string NameShihta { get; set; }

        public string RuNameShihta { get; set; }

        public double Fe { get; set; }

        public double FeO { get; set; }

        public double Fe2O3 { get; set; }

        public double SiO2 { get; set; }

        public double Al2O3 { get; set; }

        public double CaO { get; set; }

        public double MgO { get; set; }

        public double S { get; set; }

        public double MnO { get; set; }

        public double Zn { get; set; }

        public double Pmpp { get; set; }

        public double H2O { get; set; }

        public double TiO2 { get; set; }

        public double Cr { get; set; }

        public static ShihtaCatalog convertTo(UBF_ShihtaComponent component)
        {
            return new ShihtaCatalog
            {
                NameShihta = component.Name,
                Fe = component.Fe,
                SiO2 = component.SiO2,
                Al2O3 = component.Al2O3,
                CaO = component.CaO,
                MgO = component.MgO,
                S = component.S,
                MnO = component.MnO,
                TiO2 = component.TiO2,
            };
        }

        public static UBF_ShihtaComponent convertFrom(ShihtaCatalog component)
        {
            return new UBF_ShihtaComponent
            {
                Name = component.NameShihta,
                Fe = component.Fe,
                SiO2 = component.SiO2,
                Al2O3 = component.Al2O3,
                CaO = component.CaO,
                MgO = component.MgO,
                S = component.S,
                MnO = component.MnO,
                TiO2 = component.TiO2
            };
        }
    }
}
