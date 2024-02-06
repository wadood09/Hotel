using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;
using BankApp.Repositories.Interfaces;

namespace BankApp.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Drop(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int sn)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string bvn)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}