using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Enums;

namespace BankApp.Models.Entities
{
    public class Profile : BaseEntity
    {
        public string UserEmail;
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Address;
        public Gender Gender;
        public DateTime Dob;

        public Profile(int sN, string userEmail, string firstName, string lastName, string phoneNumber, string address, Gender gender, DateTime dob) : base(sN) 
        {
            UserEmail = userEmail;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Dob = dob;
        }
    }
}