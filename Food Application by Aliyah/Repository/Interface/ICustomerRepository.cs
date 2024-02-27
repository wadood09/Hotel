using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Application_Project.Repository.Interface
{
    public interface ICustomerRepository
    {
        public User Get(Func<User, bool> pred);
        public List<User> GetAll();
         void ReadAllFromFile();
         void RefreshFile();
    }
}