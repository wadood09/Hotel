using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string firstname, string lastname, string username, string email, string password, bool isAdmin = false) 
        { 
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
