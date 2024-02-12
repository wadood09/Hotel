using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Models.Enums;
using EC.Repositories.Implementations;
using EC.Repositories.Interfaces;
using EC.Services.Interfaces;

namespace EC.Services.Implementations
{
    public class ManagerService : IManagerService
    {
        IUserRepository _userRepo = new UserRepository();
        IManagerRepository _managerRepo = new ManagerRepository();
        public Manager RegisterManager(string email, string password, string firstName, string lastName, string phone, string address, Gender gender)
        {
            var exists = _userRepo.Get(email);
            if(exists is not null)
            {
                return null;
            }
            var user = new User()
            {
                Email = email,
                Password = password,
                Role = "Manager",
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phone,
                Gender = gender,
                Wallet = 0,
            };

            _userRepo.Drop(user);

            var manager = new Manager()
            {
                StaffNumber = $"CLH/STF/{new Random().Next(1111,9999)}",
                UserEmail = user.Email,
            };

            _managerRepo.Drop(manager);

            return manager;
        }
    }
}