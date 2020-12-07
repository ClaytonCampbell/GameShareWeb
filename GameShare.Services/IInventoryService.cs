using GameShare.Models;
using GameShare.Models.Inventory;
using System.Collections.Generic;

namespace GameShare.Services
{
    public interface IInventoryService
    {
        bool CreateInventory(InventoryCreate model);
        bool DeleteInventory(int inventoryId);
        InventoryDetail GetInventoryById(int id);
        IEnumerable<InventoryListItem> GetInventories();
        bool UpdateInventory(InventoryEdit model);
    }
}
