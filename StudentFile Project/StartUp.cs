using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Context;
using StudentFile_Project.Services.Implementations;
using StudentFile_Project.Services.Interfaces;

namespace StudentFile_Project
{
    public class StartUp
    {
        FileContext file = new FileContext();
        IUserServices _userser = new UserServices();
        IExamServices _examser = new ExamServices();
        IStudentServices _studser = new StudentServices();
        IAdminServices _adser = new AdminServices();
        public void Start()
        {
            if (!Directory.Exists("Files")) Directory.CreateDirectory("Files");
            var exam = file.ExamFile;
            if (!File.Exists(exam)) File.Create(exam);
            else _examser.Update();
            var student = file.StudentFile;
            if (!File.Exists(student)) File.Create(student);
            else _studser.Update();
            var admin = file.AdminFile;
            if (!File.Exists(admin)) File.Create(admin);
            else _adser.Update();
            var user = file.UserFile;
            if (!File.Exists(user)) File.Create(user);
            else _userser.Update();
            _userser.CheckAndAddSuperAdmin();

        }
    }
}