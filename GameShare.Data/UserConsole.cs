using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Data
{
    public class UserConsole
    {
        [Key]
        public int ConsoleId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Console Name")]
        public Console Name { get; set; }
        [Required]
        [Display(Name = "For Rent")]
        public bool ForRent { get; set; }
        [ForeignKey(nameof(Inventory))]
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
