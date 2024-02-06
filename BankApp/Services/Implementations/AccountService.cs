using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Context;
using BankApp.Models.Entities;
using BankApp.Models.Enums;
using BankApp.Repositories.Implementations;
using BankApp.Repositories.Interfaces;
using BankApp.Services.Interfaces;

namespace BankApp.Services.Implementations
{
    public class AccountService : IAccountService
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        IUserRepository userRepository = new UserRepository();
        IProfileRepository profileRepository = new ProfileRepository();
        IAccountRepository accountRepository = new AccountRepository();
        public Account Open(string email, string password, string confirmPassword, string firstName, string lastName, string phoneNumber, string address, Gender gender, DateTime dob, string bvn, string nin, string accountTypeName)
        {
            var exists = customerRepository.Get(bvn);
            if(exists != null)
            {
                Console.WriteLine("you already have an acount with us");
                return null;
            }
            if(password != confirmPassword)
            {
                System.Console.WriteLine("password must match");
                return null;
            }
            var user = new User(BankAppContext.UserDb.Count + 1,email,password,"Customer");
            userRepository.Drop(user);

            var profile = new Profile(BankAppContext.ProfileDb.Count+1,email,firstName,lastName,phoneNumber,address,gender,dob);
            profileRepository.Drop(profile);

            var customer = new Customer(BankAppContext.CustomerDb.Count+1,email,bvn,nin);
            customerRepository.Drop(customer);

            var account = new Account(BankAppContext.AccountDb.Count+1,GenerateNumber(), accountTypeName, 0, bvn, AccountStatus.Active);
            accountRepository.Drop(account);
            
            return account;

        }

        private string GenerateNumber()
        {
            return $"01{new Random().Next(1111, 9999)}{new Random().Next(1111, 9999)}";
        }
    }
}