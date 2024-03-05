using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;

namespace StudentFile_Project.Context
{
    public class FileContext
    {
        public static List<Student> StudentDB = new List<Student>();
        public static List<Exam> examDB = new List<Exam>();
        public static List<User> UserDB = new List<User>();
        public static List<Admin> AdminDb = new List<Admin>();


        public string StudentFile = @"Files\Student.txt";
        public string ExamFile = @"Files\Exam.txt";
        public string UserFile = @"Files\User.txt";
        public string AdminFile = @"Files\Admin.txt";




    }
}