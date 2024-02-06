using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;
using BankApp.Models.Enums;

namespace BankApp.Services.Interfaces
{
    public interface IManagerService
    {
        Manager Register(string email, string password, string firstName, string lastName, string phoneNumber, string address, Gender gender, DateTime dob);
    }
}