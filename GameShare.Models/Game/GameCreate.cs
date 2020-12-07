using GameShare.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Models.Game
{

    public class GameCreate
    {
        [Required]
        [Display(Name = "Game Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Platform")]
        public Data.Console GameConsole { get; set; }
        [Required]
        [Display(Name = "For Share")]
        public bool ForRent { get; set; }
        [Display(Name = "Inventory Id#")]
        public int InventoryId { get; set; }
        public virtual Data.Inventory Inventory { get; set; }
    }
}
