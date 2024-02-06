using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.Models.Entities
{
    public class User : Auditables
    {
        public string Email{get;set;}
        public string Password{get;set;}
        public string Role{get;set;}
        public string Name{get;set;}

        public override string ToString()
        {
            return $"{Id}\t{Email}\t{Password}\t{Role}\t{Name}\t{IsDeleted}";
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
                Name = model[4],
                IsDeleted = bool.Parse(model[5]),
            };
        }


    }
}