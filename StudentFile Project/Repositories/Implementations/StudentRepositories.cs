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
    public class StudentRepositories : IStudentRepositories
    {
        FileContext file = new FileContext();
        public void Drop(Student student)
        {
            FileContext.StudentDB.Add(student);
            using (var str = new StreamWriter(file.StudentFile, true))
            {
                var b = JsonSerializer.Serialize(student);
                str.WriteLine(b);
            }

        }

        public List<Student> GetAll()
        {
            var get = FileContext.StudentDB;
            return get;
        }

        public Student GetByemail(string email)
        {
            foreach (var item in FileContext.StudentDB)
            {
                if (item.UserEmail == email)
                {
                    return item;
                }

            }
            return null;
        }
        public Student GetById(string id)
        {
            foreach (var item in FileContext.StudentDB)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void ReadAllFromFile()
        {
            var get = File.ReadAllLines(file.StudentFile);
            foreach (var item in get)
            {
                var c = JsonSerializer.Deserialize<Student>(item)!;
                FileContext.StudentDB.Add(c);
            }
        }

        public void RefreshFile()
        {
            using (var refs = new StreamWriter(file.StudentFile, false))
            {
                foreach (var item in FileContext.StudentDB)
                {
                    var b = JsonSerializer.Serialize(item);
                    refs.WriteLine(b);

                }
            }
        }

        public void RemoveStudent(string email)
        {
            var get = GetByemail(email);
            FileContext.StudentDB.Remove(get);
            RefreshFile();

        }


    }
}