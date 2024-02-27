using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;

namespace StudentFile_Project.Repositories.Interfaces
{
    public interface IAdminRepositories
    {
        public void Drop(Admin admin);
        public List<Admin> GetAllAdmin();
        public Admin GetById(string id);
        public void Remove(string id);
        public void RefreshFile();
        public void ReadAllFromFile();

    }
}