using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_File_Project.Models.Entities
{
    public class User : Auditables
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Dob { get; set; }
        public decimal Wallet { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public static string? LoggedInUserId { get; set; }
    }
}