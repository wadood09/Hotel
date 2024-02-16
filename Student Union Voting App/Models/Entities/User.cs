using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Union_Voting_App.Models.Enums;

namespace Student_Union_Voting_App.Models.Entities
{
    public class User : Auditables
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Pasword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
    }
}