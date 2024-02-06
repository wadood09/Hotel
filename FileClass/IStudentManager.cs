using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileClass
{
    public interface IStudentManager
    {
        Student AddStudent(Student std);
        IList<Student> GetAllStudents();
        Student GetStudent(int id);
        void DeleteStudent (int id);
        
    }
}