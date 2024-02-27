// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Implementation;

namespace Food_Application_Project.Manager.Interface
{
    public interface IManagerManage
    {
        public User Get(string email);
        public List<User> GetAll();
        User UpdateManagerRole(User user, string update);

    }
}