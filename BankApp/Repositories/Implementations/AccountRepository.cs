using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Context;
using BankApp.Models.Entities;
using BankApp.Repositories.Interfaces;

namespace BankApp.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        public void Drop(Account account)
        {
            BankAppContext.AccountDb.Add(account);
        }

        public Account Get(int sn)
        {
            var account =  BankAppContext.AccountDb.SingleOrDefault(a => a.SN == sn);
            return account;
        }

        public Account Get(string accountNumber)
        {
            var account =  BankAppContext.AccountDb.SingleOrDefault(a => a.Number == accountNumber);
            return account;
        }

        public List<Account> GetAll()
        {
            return BankAppContext.AccountDb;
        }
    }
}