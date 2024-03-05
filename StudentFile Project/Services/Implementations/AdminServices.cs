using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;
using StudentFile_Project.Repositories.Implementations;
using StudentFile_Project.Repositories.Interfaces;
using StudentFile_Project.Services.Interfaces;

namespace StudentFile_Project.Services.Implementations
{
    public class AdminServices : IAdminServices
    {
        IAdminRepositories _adminRepo = new AdminRepositories();
        IUserRepositories _userRepo = new UserRepositories();
        public Admin Create(string email)
        {
            var admin = new Admin()
            {
                UserEmail = email
            };
            _adminRepo.Drop(admin);
            return admin;
        }

        public List<Admin> GetAll()
        {
            return _adminRepo.GetAllAdmin();

        }

        public Admin GetById(string id)
        {
            return _adminRepo.GetById(id);
        }

        public void IsDeleted(string id)
        {
            var getAdmin = _adminRepo.GetById(id);
            var getUser = _userRepo.GetbyEmail(getAdmin.UserEmail);
            _userRepo.Remove(getUser.Id);
            _adminRepo.Remove(id);
        }

        public void ReadAllFromFile()
        {
            _adminRepo.ReadAllFromFile();
        }

        public void Update()
        {
            _adminRepo.RefreshFile();
        }
    }
}