using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.Models.Entities
{
    public class Customer : Auditables
    {
        public string UserEmail{get; set;}
        public string TagNumber{get; set;}

        public override string ToString()
        {
            return $"{Id}\t{UserEmail}\t{TagNumber}\t{IsDeleted}";
        }

        public Customer ToCustomer(string str)
        {
            var model = str.Split('\t');
            var id = model[0];
            var userEmail = model[1];
            var tagNumber = model[2];
            var isDeleted = bool.Parse(model[3]);

            Customer customer = new Customer()
            {
                Id = id,
                UserEmail = userEmail,
                TagNumber = tagNumber,
                IsDeleted = isDeleted
            };

            return customer;
        }
    }
}