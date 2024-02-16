using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;

namespace My_File_Project.Services.Interface
{
    public interface IAdminService
    {
        void CreateAdmin(string userEmail);
        Admin? Get(Func<Admin, bool> pred);
    }
}