using GameShare.Data;
using GameShare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Models.Inventory
{
    public class InventoryListItem
    {
        [Display(Name = "Inventory Id #")]
        public int InventoryId { get; set; }
        [Display(Name = "Console Id")]
        public int ConsoleId { get; set; }
        public virtual ICollection<Data.UserConsole> UserConsoles { get; set; } = new HashSet<Data.UserConsole>();
        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        public virtual ICollection<Data.Game> Games { get; set; } = new HashSet<Data.Game>();
        [Display(Name = "# of Consoles")]
        public int ConsoleCount { get; set; }
        [Display(Name = "# of Games")]
        public int GameCount { get; set; }
    }
}
