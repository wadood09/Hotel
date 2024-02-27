using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Dapper_Project.Models.Entities
{
    public class Customer : Auditables
    {
        public string UserEmail { get; set; } = default!;
        public static string LoggedInCustomerId { get; set; } = default!;
    }
}