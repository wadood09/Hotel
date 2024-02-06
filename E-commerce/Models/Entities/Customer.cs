using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models.Entities
{
    public class Customer : Auditable
    {
        public string UserEmail {get; set;}
        public string TagNumber {get; set;}

        public override string ToString()
        {
            return $"{Id}\t{UserEmail}\t{TagNumber}\t{IsDeleted}";
        }

        public Customer ToCustomer(string str)
        {
            string[] properties = str.Split('\t');
            return new Customer()
            {
                Id = properties[0],
                UserEmail = properties[1],
                TagNumber = properties[2],
                IsDeleted = bool.Parse(properties[3])
            };
        }
    }
}