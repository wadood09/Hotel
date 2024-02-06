using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        void Drop(Manager manager);
        Manager Get(int id);
        Manager Get(string staffNumber);
        List<Manager> GetAll();
    }
}