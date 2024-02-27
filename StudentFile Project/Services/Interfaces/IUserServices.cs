using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;
using StudentFile_Project.Model.Enum;

namespace StudentFile_Project.Services.Interfaces
{
    public interface IUserServices
    {
        User Create(string email,string userName,string firstName,string lastName,string password,int age,string role,Gender gender);
        User GetByEmail(string email);
        List<User> GetAll();
        void IsDeleted(string id);
        public  User IsLoggedIn(string email,string password);
        void Update();
        void ReadAllFromFile();
    }
}