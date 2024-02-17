using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class AdminService : IAdminService
    {
        IRepository<Admin> repository = new AdminRepository();
        public void CreateAdmin(string userId)
        {
            Admin admin = new()
            {
                UserId = userId
            };
            repository.Add(admin);
        }

        public Admin? Get(Func<Admin, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<Admin> GetSelected(Func<Admin, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public bool IsDeleted(Admin admin)
        {
            
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }
    }
}