using System.ComponentModel.DataAnnotations;

namespace WebAppi.Entities
{
    public class CocksickDB
    {
        [Key]
        public int Id { get; set; }

        public double Weight { get; set; }
        public double PercentZola { get; set; }
        public double PercentSera { get; set; }
        public double PercentValotiles { get; set; }
    }    
}
