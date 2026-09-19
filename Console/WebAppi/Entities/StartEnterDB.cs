using System.ComponentModel.DataAnnotations;

namespace WebAppi.Entities
{
    public class StartEnterDB
    {
        [Key]
        public int Id { get; set; }
        public double osnovnost { get; set; }
        public double FeOinAgl { get; set; }
        public double DolomyteInAgl { get; set; }
    }
}
