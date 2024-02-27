using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;

namespace StudentFile_Project.Repositories.Interfaces
{
    public interface IExamRepositories
    {
        public void Drop(Exam exam);
        public List<Exam> GetAllExam();
        public Exam GetById(string id);
        public void ReadAllFromFile();
        public void RefreshFile();
        public void Remove(string id);
    }
}