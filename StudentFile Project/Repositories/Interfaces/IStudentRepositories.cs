using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;
using StudentFile_Project.Context;

namespace StudentFile_Project.Repositories.Interfaces
{
    public interface IStudentRepositories
    {
        public void Drop (Student student);   
        public Student GetByemail(string email);
        public Student GetById(string id);
        public List<Student> GetAll(); 
        public void RemoveStudent(string email);
        public void ReadAllFromFile();
        public void RefreshFile();
        
    }
}