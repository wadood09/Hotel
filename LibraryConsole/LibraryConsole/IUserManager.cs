using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole
{
    internal interface IUserManager
    {
        void RegisterUser(string firstname, string lastname, string username, string email, string password);
        bool Login(string username, string password);
        void RemoveUser(string username);
        IEnumerable<User> GetUsers();
        User GetUser(string username);
        User GetCurrentUser();
    }
}
