using GameShare.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Models.UserConsole
{
    public class UserConsoleCreate
    {
        [Required]
        [Display(Name = "Console Name")]
        public Data.Console Name { get; set; }
        [Required]
        [Display(Name = "For Share")]
        public bool ForRent { get; set; }
        [Display(Name = "Inventory Id#")]
        public int InventoryId { get; set; }
        public virtual Data.Inventory Inventory { get; set; }
    }
}
