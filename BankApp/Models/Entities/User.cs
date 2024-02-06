using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Entities
{
    public class User : BaseEntity
    {
        public string Email;
        public string Password;
        public string Role;

        public User(int sN, string email, string password, string role) : base(sN)
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}