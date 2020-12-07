using GameShare.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Models.Game
{
    public class GameEdit
    {
        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        [Display(Name = "Game Name")]
        public string Name { get; set; }
        [Display(Name = "Platform")]
        public Data.Console GameConsole { get; set; }
        [Display(Name = "For Share")]
        public bool ForRent { get; set; }
        [Display(Name = "Inventory Id#")]
        public int InventoryId { get; set; }
        public virtual Data.Inventory Inventory { get; set; }
    }
}
