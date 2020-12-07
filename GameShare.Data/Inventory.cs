using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Data
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public Guid OwnerId { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();
        public ICollection<UserConsole> UserConsoles { get; set; } = new List<UserConsole>();
    }
}
