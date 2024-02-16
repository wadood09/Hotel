using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Repositories.Interface;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class StudentRepository : IRepository<Student> 
    {
        public void Drop(Student student)
        {
            ContextDB.Students.Add(student);

            using (StreamWriter writer = new(ContextDB.StudentFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(student));
            }
        }

        public Student Get(Func<Student, bool> pred)
        {
            return ContextDB.Students.SingleOrDefault(pred);
        }

        public List<Student> GetAll()
        {
            return ContextDB.Students;
        }

        public List<Student> GetSelected(Func<Student, bool> pred)
        {
            return ContextDB.Students.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] students = File.ReadAllLines(ContextDB.StudentFile);
            foreach (string student in students)
            {
                ContextDB.Students.Add(JsonSerializer.Deserialize<Student>(student));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.StudentFile, false))
            {
                foreach (Student student in ContextDB.Students)
                {
                    writer.WriteLine(JsonSerializer.Serialize(student));
                }
            }
        }
    }
}