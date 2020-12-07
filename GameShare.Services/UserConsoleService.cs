using GameShare.Data;
using GameShare.Models;
using GameShare.Models.UserConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Services
{
    public class UserConsoleService : IUserConsoleService
    {
        private readonly Guid _userId;
        public UserConsoleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUserConsole(UserConsoleCreate model)
        {
            var entity =
                new UserConsole()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    ForRent = model.ForRent,
                    InventoryId = model.InventoryId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserConsoles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserConsoleListitem> GetUserConsoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserConsoles
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UserConsoleListitem
                                {
                                    ConsoleId = e.ConsoleId,
                                    Name = e.Name,
                                    ForRent = e.ForRent,
                                    InventoryId = e.InventoryId,
                                    Inventory = e.Inventory
                                }
                        );

                return query.ToArray();
            }
        }

        public UserConsoleDetail GetUserConsoleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserConsoles
                        .Single(e => e.ConsoleId == id && e.OwnerId == _userId);
                return new UserConsoleDetail
                {
                    ConsoleId = entity.ConsoleId,
                    Name = entity.Name,
                    ForRent = entity.ForRent,
                    InventoryId = entity.InventoryId,
                    Inventory = entity.Inventory
                };
            }
        }

        public bool UpdateUserConsole(UserConsoleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserConsoles
                        .Single(e => e.ConsoleId == model.ConsoleId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.ForRent = model.ForRent;
                entity.InventoryId = model.InventoryId;
                entity.Inventory = model.Inventory;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUserConsole(int consoleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserConsoles
                        .Single(e => e.ConsoleId == consoleId && e.OwnerId == _userId);

                ctx.UserConsoles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
