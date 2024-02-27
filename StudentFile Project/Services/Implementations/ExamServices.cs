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
    public class ExamServices : IExamServices
    {
        IExamRepositories _examRepo = new ExamRepositories();
        public Exam Create(double score,string grade,double percentage)
        {
            var exam = new Exam()
            {
               
               Percentage = percentage,
               Grade = grade,
               StudentId = Student.LoggedInStudentId,
               Score = score
            };
            _examRepo.Drop(exam);
            return exam;
        }

        public List<Exam> GetAll()
        {
            return _examRepo.GetAllExam();
        }

        public Exam GetById(string id)
        {
            return _examRepo.GetById(id);
        }

        public void IsDeleted(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsExamDone()
        {
            foreach(var item in _examRepo.GetAllExam())
            {
                if(item.StudentId == Student.LoggedInStudentId)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReadAllFromFile()
        {
            _examRepo.ReadAllFromFile();
        }

        public void Update()
        {
            _examRepo.RefreshFile();
        }
    }
}