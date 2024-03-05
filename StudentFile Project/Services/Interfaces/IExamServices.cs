using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;

namespace StudentFile_Project.Services.Interfaces
{
    public interface IExamServices
    {
        Exam Create(double score,string grade,double percentage);
        public Exam GetByStudentId(string studentId);
        List<Exam> GetAll();
        bool IsExamDone();
        void IsDeleted(string id);
        void Update();
        void ReadAllFromFile();
    }
}