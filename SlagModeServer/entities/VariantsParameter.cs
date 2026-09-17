using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SlagModeServer.entities.NewStructure
{
    [PrimaryKey(nameof(VariantID))]
    public class VariantsParameter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VariantID {  get; set; }
        [JsonIgnore]
        [ForeignKey (nameof(UserID))]
        public Users? User { get; set; }
        public int UserID { get; set; }

        public string DateVariant { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(BlastFurnaceID))]
        public BlastFurnaces? BlastFurnace { get; set; }
        public int BlastFurnaceID { get; set; }

        public string? VariantName { get; set; }

        public double IronProduction { get; set; }

        public double CokeConsumption { get; set; }

        public double SlagOutput {  get; set; }

        public double DustRemoval { get; set; }

        public double BlowPressure { get; set; }

        public double BlowTemperature { get; set; }

        public double BlowMoisture { get; set; }

        public double BlowO2 { get; set; }

        public double NaturalGasConsumption { get; set; }

        public double IronTemperature { get; set; }

        public double IronSi { get; set; }

        public double IronS { get; set; }

        public double IronMn { get; set; }

        public double IronC { get; set; }

        public double IronP { get; set; }

        public double IronTi { get; set; }

        public double SlagSiO2 { get; set; }

        public double SlagCaO { get; set; }

        public double SlagAl2O3 { get; set; }

        public double SlagMgO { get; set; }

        public double SlagS { get; set; }

        public double SlagTiO2 { get; set; }

        public double CokeAsh { get; set; }

        public double CokeS { get; set; }

        public double CokeVolatile { get; set; }
        public double CokeAshFe { get; set; }

        public double CokeAshCaO { get; set; }

        public double CokeAshSiO2 { get; set; }

        public double CokeAshAl2O3 { get; set; }

        public double CokeAshMgO { get; set; }

        public double CokeAshP { get; set; }
    }
}
