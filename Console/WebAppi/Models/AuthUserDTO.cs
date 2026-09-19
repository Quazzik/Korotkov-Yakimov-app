using Console;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAppi.Models
{
    public class AuthUserDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }    
}
