using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;
using BankApp.Repositories.Interfaces;

namespace BankApp.Repositories.Implementations
{
    public class ProfileRepository : IProfileRepository
    {
        public void Drop(Profile profile)
        {
            throw new NotImplementedException();
        }

        public Profile Get(string userEmail)
        {
            throw new NotImplementedException();
        }

        public List<Profile> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}