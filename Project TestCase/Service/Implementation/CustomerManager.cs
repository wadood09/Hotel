using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class CustomerManager : IManager<Customer>
    {
        IRepository<Customer> Repository = new CustomerRepository();
        public bool IsExist(string email)
        {
            foreach (Customer customer in HotelContext.Customers)
            {
                if (customer.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login(string email, string password)
        {
            foreach (Customer customer in HotelContext.Customers)
            {
                if (customer.Email == email && customer.Password == password)
                {
                    Customer.LoggedInCustomerId = customer.Id;
                    return true;
                }
            }
            return false;
        }

        public void Register(Customer customer)
        {
            if (IsExist(customer.Email))
            {
                Console.WriteLine($"Admin with email {customer.Email} already exists");
            }
            else
            {
                Repository.Add(customer);
                Console.WriteLine("Registration Successfull");
            }
        }
    }
}