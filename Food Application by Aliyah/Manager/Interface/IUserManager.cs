using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Application_Project.Manager.Interface
{
    public interface IUserManager
    {
        public User Login(string email, string passWord);
        void CheckAndAddSuperAdmin();
        public User Get(Func<User, bool> pred);
        public User GetUser(string email);
        public List<User> GetAll();
        bool Check(string email);
        public User GetLoggedINUser(User user);
        void UpdateList();
        public User Create(string firstName, string lastName, string phoneNumber, string address, string email, string passWord, string role);
    }
}