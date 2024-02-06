using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Entities;

namespace BankApp.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        void Drop(Profile profile);
        Profile Get(string userEmail);
        List<Profile> GetAll();
    }
}