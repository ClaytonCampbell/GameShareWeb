using GameShare.Data;
using GameShare.Models;
using GameShare.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Services
{
    public class GameService : IGameService
    {
        private readonly Guid _userId;
        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    GameConsole = model.GameConsole,
                    ForRent = model.ForRent,
                    InventoryId = model.InventoryId,
                    Inventory = model.Inventory
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    Name = e.Name,
                                    GameConsole = e.GameConsole,
                                    ForRent = e.ForRent,
                                    InventoryId = e.InventoryId
                                }
                        );

                return query.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == id && e.OwnerId == _userId);
                return new GameDetail
                {
                    GameId = entity.GameId,
                    Name = entity.Name,
                    GameConsole = entity.GameConsole,
                    ForRent = entity.ForRent,
                    InventoryId = entity.InventoryId,
                    Inventory = entity.Inventory
                };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == model.GameId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.GameConsole = model.GameConsole;
                entity.ForRent = model.ForRent;
                entity.InventoryId = model.InventoryId;
                entity.Inventory = model.Inventory;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameId && e.OwnerId == _userId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
