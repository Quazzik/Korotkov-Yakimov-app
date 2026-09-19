using Console;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAppi.Entities
{
    public class ShihtaComponentsDB
    {
        [Key]
        public int ID { get; set; }
        public int PresetId { get; set; }
        /*[ForeignKey(nameof(PresetId))]*/
        [JsonIgnore]
        public DefaultPreset Preset { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Wet { get; set; }
        public double PMPP { get; set; }

        public double Fe { get; set; }
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
    }
}
