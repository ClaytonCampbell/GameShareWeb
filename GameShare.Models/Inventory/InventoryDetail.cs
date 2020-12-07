using GameShare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Models.Inventory
{
    public class InventoryDetail
    {
        public int InventoryId { get; set; }
        public ICollection<Data.Game> Games { get; set; } = new List<Data.Game>();
        public ICollection<Data.UserConsole> UserConsoles { get; set; } = new List<Data.UserConsole>();
    }
}
