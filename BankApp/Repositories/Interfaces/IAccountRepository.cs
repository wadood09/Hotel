using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        void Drop(Account account);
        Account Get(int sn);
        Account Get(string accountNumber);
        List<Account> GetAll();
    }
}