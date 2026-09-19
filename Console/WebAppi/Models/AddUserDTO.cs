using Console;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAppi.Models
{
    public class AddUserDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }    
}
