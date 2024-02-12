using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Models.Enums;

namespace EC.Services.Interfaces
{
    public interface IManagerService
    {
        Manager RegisterManager(string email, string password, string firstName, string lastName, string phone, string address, Gender gender);
    }
}