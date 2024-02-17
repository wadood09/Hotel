using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_File_Project.Models.Entities
{
    public class Customer : Auditables
    {
        public string? UserId { get; set; }
        public static string? LoggedInCustomerId { get; set; }
    }
}