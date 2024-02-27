using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using StudentFile_Project.Context;
using StudentFile_Project.Model.Entities;
using StudentFile_Project.Repositories.Interfaces;

namespace StudentFile_Project.Repositories.Implementations
{
    public class ExamRepositories : IExamRepositories
    {
        FileContext file = new FileContext();

        public void ReadAllFromFile()
        {
            var exam = File.ReadAllLines(file.ExamFile);
            foreach (var item in exam)
            {
                var c = JsonSerializer.Deserialize<Exam>(item)!;
                FileContext.examDB.Add(c);
            }
        }

        public void Drop(Exam exam)
        {
            FileContext.examDB.Add(exam);
            using (var str = new StreamWriter(file.ExamFile, true))
            {
                var b = JsonSerializer.Serialize(exam);
                str.WriteLine(b);
            }
        }

        public List<Exam> GetAllExam()
        {
            var get = FileContext.examDB;
            return get;
        }

        public Exam GetById(string id)
        {
            foreach (var item in FileContext.examDB)
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null!;
        }

        public void RefreshFile()
        {
            using (var refs = new StreamWriter(file.ExamFile, false))
            {
                foreach (var item in FileContext.examDB)
                {
                    var b = JsonSerializer.Serialize(item);
                    refs.WriteLine(b);

                }
            }
        }

        public void Remove(string id)
        {
            var get = GetById(id);
            FileContext.examDB.Remove(get);
            RefreshFile();
        }
    }
}