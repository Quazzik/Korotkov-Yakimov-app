using System.ComponentModel.DataAnnotations;

namespace WebAppi.Entities
{
    public class UserDB
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
    }    
}
