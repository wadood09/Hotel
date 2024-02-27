using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;

namespace StudentFile_Project.Services.Interfaces
{
    public interface IAdminServices
    {
        Admin Create(string email);
        Admin GetById(string id);
        List<Admin> GetAll();
        void IsDeleted(string id);
        void Update();
        void ReadAllFromFile();
    }
}