using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EC.Context;
using EC.Models.Entities;
using EC.Repositories.Interfaces;

namespace EC.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        FileContext _context = new FileContext();
        public void Drop(Customer customer)
        {
            FileContext.Customers.Add(customer);

            using(var str = new StreamWriter(_context.CustomerFile, true))
            {
                str.WriteLine(JsonSerializer.Serialize(customer));
            }
        }

        public Customer Get(string email)
        {
            var customer = FileContext.Customers.SingleOrDefault(a => a.UserEmail == email);
            return customer;
        }

        public List<Customer> GetAll()
        {
            return FileContext.Customers;
        }

        public void ReadAllFromFile()
        {
            var customers = File.ReadAllLines(_context.CustomerFile);

            foreach (var item in customers)
            {
                FileContext.Customers.Add(JsonSerializer.Deserialize<Customer>(item));
            }
        }

        public void RefreshFile()
        {
            using(var str = new StreamWriter(_context.CustomerFile, false))
            {
                foreach (var item in FileContext.Customers)
                {
                    str.WriteLine(JsonSerializer.Serialize(item));
                }
            }
        }
    }
}