using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;

namespace My_File_Project.Services.Interface
{
    public interface IAdminService
    {
        void CreateAdmin(string userId);
        Admin? Get(Func<Admin, bool> pred);
        List<Admin> GetSelected(Func<Admin, bool> pred);
        bool IsDeleted(Admin admin);
        void UpdateFile();
        void UpdateList();
    }
}