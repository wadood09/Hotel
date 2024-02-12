using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Repositories.Interfaces;

namespace EC.Repositories.Implementations
{
    public class ManagerRepository : IManagerRepository
    {
        public void Drop(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Manager Get(string email)
        {
            throw new NotImplementedException();
        }

        public List<Manager> GetAll()
        {
            throw new NotImplementedException();
        }

        public void ReadAllFromFile()
        {
            throw new NotImplementedException();
        }

        public void RefreshFile()
        {
            throw new NotImplementedException();
        }
    }
}