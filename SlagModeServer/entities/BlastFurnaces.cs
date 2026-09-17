using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlagModeServer.entities.NewStructure
{
    [PrimaryKey(nameof(FurnaceID))]
    public class BlastFurnaces
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FurnaceID { get; set; }
        public string Name { get; set; }
    }
}
