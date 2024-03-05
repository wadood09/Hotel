using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;
using StudentFile_Project.Model.Enum;
using StudentFile_Project.Repositories.Implementations;
using StudentFile_Project.Repositories.Interfaces;
using StudentFile_Project.Services.Interfaces;

namespace StudentFile_Project.Services.Implementations
{
    public class UserServices : IUserServices
    {
        IUserRepositories _userRepo = new UserRepositories();
        IStudentServices _studServ = new StudentServices();
        IAdminServices _adminServ = new AdminServices();
        public User Create(string email,string userName,string firstName,string lastName,string password,int age,string role,Gender gender)
        {
            if(IsExist(email) == false)
            {
            var user = new User()
            {
                UserName = userName,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PassWord = password,
                Age = age,
                Role = role,
                Gender = gender
            };
            _userRepo.Drop(user);
            if(role == "STUDENT")
            {
             _studServ.Create(email);
            }
            else
            {
             _adminServ.Create(email);
            }
            return user;
            }
            else
            {
                return null;
            }
            
            
        }
        public void CheckAndAddSuperAdmin()
        {
            Create("admin@gmail.com","Jonatee","Jonathan","Oluwole","admin",35,"SUPERADMIN",Gender.Male);
        }
        public bool IsExist(string email)
        {
            if(GetByEmail(email) is null)
            {
                  return false;
            }
            return true;
        }
        public  User IsLoggedIn(string email,string passWord)
        {
           User? userLogin = _userRepo.GetAll().FirstOrDefault(u => u.Email == email && u.PassWord == passWord);
           if(userLogin is null)
           {
            return null;
           }
           else
           {
            User.LoggedInUser = userLogin;
            return userLogin;

           }
        }


        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public User GetByEmail(string email)
        {
            return _userRepo.GetbyEmail(email);
        }

        public void IsDeleted(string id)
        {
            _userRepo.Remove(id);
        }

        public void ReadAllFromFile()
        {
          _userRepo.ReadAllFromFile();
        }

        public void Update()
        {
            _userRepo.RefreshFile();
        }
    }
}