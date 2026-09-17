using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlagModeServer.entities.NewStructure
{
    [PrimaryKey(nameof(UserID))]
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
