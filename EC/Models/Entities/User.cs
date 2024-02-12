using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Enums;

namespace EC.Models.Entities
{
    public class User : Auditables
    {
        public string Email{get;set;}
        public string Password{get;set;}
        public string Role{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string PhoneNumber{get;set;}
        public string Address{get;set;}
        public Gender Gender{get;set;}
        public double Wallet{get; set;}

        public override string ToString()
        {
            return $"{Id}\t{Email}\t{Password}\t{Role}\t{FirstName}\t{IsDeleted}";
        }

        public User ToUser(string str)
        {
            var model = str.Split('\t');
            return new User()
            {
                Id = model[0],
                Email = model[1],
                Password = model[2],
                Role = model[3],
                FirstName = model[4],
                IsDeleted = bool.Parse(model[5]),
            };
        }


    }
}