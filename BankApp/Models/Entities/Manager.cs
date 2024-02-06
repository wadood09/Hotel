using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Entities
{
    public class Manager : BaseEntity
    {
        public string UserEmail;
        public string StaffNumber;

        public Manager(int sN, string userEmail, string staffNumber) : base(sN)
        {
            UserEmail = userEmail;
            StaffNumber = staffNumber;
        }
    }
}