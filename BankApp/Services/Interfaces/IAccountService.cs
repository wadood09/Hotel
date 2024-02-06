using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;
using BankApp.Models.Enums;

namespace BankApp.Services.Interfaces
{
    public interface IAccountService
    {
        Account Open(string email, string password, string confirmPassword, string firstName, string lastName, string phoneNumber, string address, Gender gender, DateTime dob, string bvn, string nin, string accountTypeName);
    }
}