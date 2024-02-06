using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Entities
{
    public class Customer : BaseEntity
    {
        public string UserEmail;
        public string BVN;
        public string NIN;

        public Customer(int sN, string userEmail,string bvn, string nin) : base(sN)
        {
            UserEmail = userEmail;
            BVN = bvn;
            NIN = nin;
        }
    }
}