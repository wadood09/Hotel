using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        void Drop(Manager manager);
        void RefreshFile();
        void ReadAllFromFile();
        Manager Get(string email);
        List<Manager> GetAll();
    }
}