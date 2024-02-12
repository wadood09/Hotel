using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Repositories.Implementations;
using EC.Repositories.Interfaces;
using EC.Services.Interfaces;

namespace EC.Services.Implementations
{
    public class UserService : IUserService
    {
        IUserRepository _userRepo = new UserRepository();
        User currentUser = null;
        public User Login(string email, string password)
        {
            var response = _userRepo.Get(email);
            if(response == null)
            {
                return null;
            }
            if(response.Password != password)
            {
                return null;
            }
            
            currentUser = response;
            return response;
        }
    }
}