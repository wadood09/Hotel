using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void Drop(Customer customer);
        void RefreshFile();
        void ReadAllFromFile();
        Customer Get(string email);
        List<Customer> GetAll();
    }
}