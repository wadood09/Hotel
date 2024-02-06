using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models.Entities
{
    public class User : Auditable
    {
        public string Email {get; set;}
        public string Password {get; set;}
        public string Role {get; set;}
        public string Name {get; set;}

        public override string ToString()
        {
            return $"{Id}\t{Email}\t{Password}\t{Role}\t{Name}\t{IsDeleted}";
        }

        public User ToUser(string str)
        {
            string[] properties = str.Split('\t');
            return new User()
            {
                Id = properties[0],
                Email = properties[1],
                Password = properties[2],
                Role = properties[3],
                Name = properties[4],
                IsDeleted = bool.Parse(properties[5])
            };
        }
    }
}