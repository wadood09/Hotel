using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole
{
    internal class UserMemoryManager : IUserManager
    {
        //In memory collections
        private readonly List<User> users = new List<User>();
        private readonly User adminUser;
        private User currentUser;

        public UserMemoryManager()
        {
            //mocking an admin  user
            adminUser = new User("John", "Doe", "admin", "johndoe@gmail.com", "admin", true);
            users.Add(adminUser);
        }
        public User GetCurrentUser()
        {
            return currentUser;
        }

        public User GetUser(string username)
        {
            User user = null;
            foreach (var x in users)
            {
                if (x.UserName == username)
                {
                    user = x;
                    break;
                }
            }

            if(user  == null)
            {
                Console.WriteLine("User doest not exist");
                return null;    
            }
            else
            {
                return user;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            //var allUsers = users;
            return users;
        }

        public bool Login(string username, string password)
        {
            //var user = users.FirstOrDefault(x => x.UserName == username && x.Password == password);

            User user = null;
            foreach(var x in users)
            {
                if(x.UserName == username && x.Password == password)
                {
                    user = x;
                    break;
                }
            }
           
            if(user != null)
            {
                Console.WriteLine("User logged in successfully");
                currentUser = user;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid credentials");
                return false;
            }
        }

        public void RegisterUser(string firstname, string lastname, string username, string email, string password)
        {
            User user = null;
            foreach(var x in users)
            {
                if(x.UserName == username)
                {
                    user = x;
                }
            }
            if(user != null)
            {
                Console.WriteLine($"user with username {username} already exist");
            }
            else
            {
                user = new User(firstname, lastname, username, email, password);
                users.Add(user);
                Console.WriteLine("user registered succesfully");
            }
        }

        public void RemoveUser(string username)
        {
            User user = null;
            foreach(var x in users)
            {
                if(x.UserName == username)
                {
                    user = x;
                    break;
                }
            }

            if(user is not null)
            {
                users.Remove(user);
            }
            else
            {
                Console.WriteLine($"User with {username} does not exist");
            }
        }
    }
}
