using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;
using BankApp.Repositories.Interfaces;

namespace BankApp.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public void Drop(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(string email)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}