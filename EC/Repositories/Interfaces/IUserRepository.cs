using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Drop(User user);
        User Get(string email);
        List<User> GetAll();
        void RefreshFile();
        void ReadAllFromFile();
    }
}