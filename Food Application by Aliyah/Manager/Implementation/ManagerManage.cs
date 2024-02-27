using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;
using Org.BouncyCastle.Crypto.Operators;

namespace Food_Application_Project.Manager.Implementation
{
    public class ManagerManage : IManagerManage
    {
        IManagerRepository managerRepo = new ManagerRepository();
        public ManagerManage()
        {
            managerRepo.ReadAllFromFile();
        }
        
        public User Get(string email)
        {
            var exist = managerRepo.Get(a => a.Email == email);
            if (exist == null)
            {
                return null;
            }
            return exist;
        }

        public List<User> GetAll()
        {
            return managerRepo.GetAll();
        }

        public User UpdateManagerRole(User user, string update)
        {
            var manager = managerRepo.UpdateManagerRole(user, update);
            if(manager != null)
            {
                return manager;
            }
            return null;
        }
    }
}