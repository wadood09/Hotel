using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Context;
using BankApp.Models.Entities;
using BankApp.Repositories.Interfaces;

namespace BankApp.Repositories.Implementations
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        public void Drop(AccountType accountType)
        {
            BankAppContext.AccountTypeDb.Add(accountType);
        }

        public AccountType Get(int sn)
        {
            var type = BankAppContext.AccountTypeDb.SingleOrDefault(a => a.SN == sn);
            return type;
        }

        public AccountType Get(string name)
        {
            var type = BankAppContext.AccountTypeDb.SingleOrDefault(a => a.Name == name);
            return type;
        }

        public List<AccountType> GetAll()
        {
            return BankAppContext.AccountTypeDb;
        }
    }
}