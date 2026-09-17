using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SlagModeServer.entities.NewStructure
{
    [PrimaryKey(nameof(VariantID), nameof(ComponentID))]
    public class VariantCharges
    {
        [ForeignKey(nameof(VariantID))]
        public VariantsParameter? VariantParameters { get; set; }
        public int VariantID { get ; set; }
        [ForeignKey(nameof(ComponentID))]
        public ShihtaCatalog? CatalogElem { get; set; }
        public int ComponentID { get; set; }

        public double Consumption { get; set; }
        public double ShihtaType { get; set; }
        public double ShihtaFe { get; set; }
        public double ShihtaFeO { get; set; }
        public double Fe2O3 { get; set; }
        public double ShihtaSiO2 { get; set; }
        public double ShihtaAl2O3 { get; set; }
        public double ShihtaCaO { get; set; }
        public double ShihtaMgO { get; set; }
        public double ShihtaP { get; set; }
        public double ShihtaS { get; set; }
        public double ShihtaMnO { get; set; }
        public double ShihtaZn { get; set; }
        public double ShihtaPmpp { get; set; }
        public double ShihtaH2O { get; set; }
        public double ShihtaTiO2 { get; set; }
        public double ShihtaCr { get; set; }
    }
}
