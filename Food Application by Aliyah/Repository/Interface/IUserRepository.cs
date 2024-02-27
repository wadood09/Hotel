using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Application_Project.Repository.Interface
{
    public interface IUserRepository
    {
        User Create(User user);
        // User CreateManager(User user);
        void CheckAndAddSuperAdmin();
        User Login(string email,string passWord);
        User Get(Func<User, bool> pred);
        List<User> GetAll();
        void ReadAllFromFile();
        void RefreshFile();
        User CreateManager(User user);
    }
}