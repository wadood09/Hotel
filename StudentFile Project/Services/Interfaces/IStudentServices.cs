using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;

namespace StudentFile_Project.Services.Interfaces
{
    public interface IStudentServices
    {
        Student Create(string email);
        Student GetByEmail(string email);
        List<Student> GetAll();
        void IsDeleted(string id);
        void Update();
        void ReadAllFromFile();
    }
}