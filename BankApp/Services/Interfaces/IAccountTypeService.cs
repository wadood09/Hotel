using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Services.Interfaces
{
    public interface IAccountTypeService
    {
        Account CreateAccountType(string name, double openingBalance, double minimumBalance, double transferLimit);
    }
}