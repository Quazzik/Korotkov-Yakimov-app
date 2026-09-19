using Console;
using System.ComponentModel.DataAnnotations;

namespace WebAppi.Entities
{
    public class ZolaOfCocsickDB
    {
        [Key]
        public int Id { get; set; }
        public double Fe { get; set; }
        public double CaO { get; set; }
        public double SiO2 { get; set; }
        public double Al2O3 { get; set; }
        public double MgO { get; set; }
        public double P { get; set; }
    }
}
