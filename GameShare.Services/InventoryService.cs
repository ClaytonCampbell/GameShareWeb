using GameShare.Data;
using GameShare.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Guid _userId;

        public InventoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateInventory(InventoryCreate model)
        {
            var entity =
                new Inventory()
                {
                    OwnerId = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Inventories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InventoryListItem> GetInventories()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .Inventories
                        .Include(nameof(UserConsole))
                        .Include(nameof(Game))
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new InventoryListItem
                                {
                                    InventoryId = e.InventoryId,
                                    UserConsoles = e.UserConsoles,
                                    Games = e.Games,
                                    GameCount = e.Games.Count,
                                    ConsoleCount = e.UserConsoles.Count
                                }
                        );

                return query.ToArray();
            }
        }

        public InventoryDetail GetInventoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inventories
                        .Include(e => e.Games)
                        .Include(e => e.UserConsoles)
                        .Single(e => e.InventoryId == id && e.OwnerId == _userId);
                return
                    new InventoryDetail
                    {
                        InventoryId = entity.InventoryId,
                        Games = entity.Games,
                        UserConsoles = entity.UserConsoles
                    };
            }
        }

        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Inventories.Single(e => e.InventoryId == model.InventoryId && e.OwnerId == _userId);


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInventory(int inventoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inventories
                        .Single(e => e.InventoryId == inventoryId && e.OwnerId == _userId);

                if (entity.UserConsoles.Count > 0 || entity.Games.Count > 0)
                {

                    return false;
                }
                else
                {
                    ctx.Inventories.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }

            }

        }
    }
}
