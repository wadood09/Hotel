using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void Drop(Customer customer);
        Customer Get(int sn);
        Customer Get(string bvn);
        List<Customer> GetAll();
    }
}