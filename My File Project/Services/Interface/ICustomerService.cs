using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;

namespace My_File_Project.Services.Interface
{
    public interface ICustomerService
    {
        void CreateCustomer(string userEmail);
        Customer? Get(Func<Customer, bool> pred);
    }
}