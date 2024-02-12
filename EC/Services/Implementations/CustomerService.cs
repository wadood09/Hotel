using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Models.Enums;
using EC.Repositories.Implementations;
using EC.Repositories.Interfaces;
using EC.Services.Interfaces;

namespace EC.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        IUserRepository _userRepo = new UserRepository();
        ICustomerRepository _customerRepo = new CustomerRepository();
        public Customer RegisterCustomer(string email, string password, string firstName, string lastName, string phone, string address, Gender gender)
        {
            var exists = _userRepo.Get(email);
            if(exists is not null)
            {
                return null;
            }
            var user = new User()
            {
                Email = email,
                Password = password,
                Role = "Customer",
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phone,
                Gender = gender,
                Wallet = 0,
            };

            _userRepo.Drop(user);

            var customer = new Customer()
            {
                TagNumber = $"CLH/CST/{new Random().Next(1111,9999)}",
                UserEmail = user.Email,
            };

            _customerRepo.Drop(customer);

            return customer;
        }
    }
}