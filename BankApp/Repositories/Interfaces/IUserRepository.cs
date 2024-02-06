using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Drop(User user);
        User Get(string email);
        List<User> GetAll();
    }
}