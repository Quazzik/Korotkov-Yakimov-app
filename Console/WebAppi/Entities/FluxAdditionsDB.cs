using System.ComponentModel.DataAnnotations;

namespace WebAppi.Entities
{
    public class FluxAdditionsDB
    {
        [Key]
        public int Id { get; set; }
        public double IzvestnyakCaO { get; set; }
        public double IzvestnyakSiO2 { get; set; }
        public double IzvestnyakAl2O3 { get; set; }
        public double IzvestnyakMgO { get; set; }

        public double DolomyteCaO { get; set; }
        public double DolomyteSiO2 { get; set; }
        public double DolomyteAl2O3 { get; set; }
        public double DolomyteMgO { get; set; }
    }
}
