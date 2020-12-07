using GameShare.Models;
using GameShare.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Services
{
    public interface IGameService
    {
        bool CreateGame(GameCreate model);
        bool DeleteGame(int gameId);
        GameDetail GetGameById(int id);
        IEnumerable<GameListItem> GetGames();
        bool UpdateGame(GameEdit model);
    }
}
