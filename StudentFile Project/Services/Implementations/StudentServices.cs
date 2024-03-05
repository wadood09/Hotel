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
    public class StudentServices : IStudentServices
    {
        IStudentRepositories _studentRepo = new StudentRepositories();
        IUserRepositories _userRepo = new UserRepositories();
        public Student Create(string email)
        {
            var student = new Student()
            {
                UserEmail = email,
                RegNumber = default!
            };
            _studentRepo.Drop(student);
            return student;

        }

        public List<Student> GetAll()
        {
            return _studentRepo.GetAll();
        }

        public Student GetByEmail(string email)
        {
            return _studentRepo.GetByemail(email);
        }
        public Student GetById(string id)
        {
            return _studentRepo.GetById(id);
        }

        public void IsDeleted(string email)
        {
            var getStudent = _studentRepo.GetByemail(email);
            var getUser = _userRepo.GetbyEmail(email);
            _userRepo.Remove(getUser.Email);
            _studentRepo.RemoveStudent(email);
        }

        public void ReadAllFromFile()
        {
           _studentRepo.ReadAllFromFile();
        }

        public void Update()
        {
            _studentRepo.RefreshFile();
        }
    }
}