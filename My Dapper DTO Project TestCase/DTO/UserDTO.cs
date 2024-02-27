using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class UserResponseModel : Auditables
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Wallet { get; set; }
    }

    public class UserRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Dob { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}