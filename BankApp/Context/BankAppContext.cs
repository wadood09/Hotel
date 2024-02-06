using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Context
{
    public class BankAppContext
    {
        public static List<Account> AccountDb = new List<Account>();
        public static List<AccountType> AccountTypeDb = new List<AccountType>();
        public static List<Customer> CustomerDb = new List<Customer>();
        public static List<Manager> ManagerDb = new List<Manager>();
        public static List<Profile> ProfileDb = new List<Profile>();
        public static List<Transfer> TransferDb = new List<Transfer>();
        public static List<User> UserDb = new List<User>()
        {
            new User(1,"super@gmail.com", "pass", "SuperAdmin")
        };
    }
}