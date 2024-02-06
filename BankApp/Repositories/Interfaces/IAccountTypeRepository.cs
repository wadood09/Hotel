using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Repositories.Interfaces
{
    public interface IAccountTypeRepository
    {
        void Drop(AccountType accountType);
        AccountType Get(int sn);
        AccountType Get(string name);
        List<AccountType> GetAll();
    }
}