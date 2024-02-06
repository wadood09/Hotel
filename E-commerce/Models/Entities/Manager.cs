using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models.Entities
{
    public class Manager : Auditable
    {
        public string UserEmail {get; set;}
        public string StaffNumber {get; set;}

        public override string ToString()
        {
            return $"{Id}\t{UserEmail}\t{StaffNumber}\t{IsDeleted}";
        }

        public Manager ToManager(string str)
        {
            string[] properties = str.Split('\t');
            return new Manager()
            {
                Id = properties[0],
                UserEmail = properties[1],
                StaffNumber = properties[2],
                IsDeleted = bool.Parse(properties[3])
            };
        }
    }
}