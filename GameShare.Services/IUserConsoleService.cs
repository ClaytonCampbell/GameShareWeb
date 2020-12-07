using GameShare.Models.UserConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Services
{
    public interface IUserConsoleService
    {
        bool CreateUserConsole(UserConsoleCreate model);
        bool DeleteUserConsole(int consoleId);
        UserConsoleDetail GetUserConsoleById(int id);
        IEnumerable<UserConsoleListitem> GetUserConsoles();
        bool UpdateUserConsole(UserConsoleEdit model);
    }
}
