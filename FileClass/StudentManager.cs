using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileClass
{
    public class StudentManager : IStudentManager
    {

        private static string FileName = "/home/abdulrosheed/Folders/FileClass/Files/student.txt";

        public StudentManager()
        {
            LoadContentFromFile();
        }

        public Student AddStudent(Student std)
        {
            try
            {
                var fileExists = File.Exists(FileName);
                if (!fileExists)
                {
                        File.Create(FileName);
                        using (var str = new StreamWriter(FileName, true))
                    {
                        str.WriteLine(std.ToString());
                    };
                    Student.Students.Add(std);
                }
                else
                {
                    using (var str = new StreamWriter(FileName, true))
                    {
                        str.WriteLine(std.ToString());
                    };
                    Student.Students.Add(std);


                }
            }
            catch
            {

            }
            return std;

        }

        public void DeleteStudent(int id)
        {
            Student std = default;
            foreach (var item in Student.Students)
            {
                if (item.Id == id)
                {

                    std = item;
                    Student.Students.Remove(std);
                    break;
                }
            }

            File.WriteAllText(FileName, String.Empty);
            using (var str = new StreamWriter(FileName, true))
            {
                foreach (var item in Student.Students)
                {
                    str.WriteLine(item.ToString());
                }
            };

        }
        public void UpdateStudent(int id , string Name)
        {
            Student std = default;
            foreach (var item in Student.Students)
            {
                if (item.Id == id)
                {
                    item.Name = Name;
                    break;
                }
            }
            File.WriteAllText(FileName, String.Empty);
            using (var str = new StreamWriter(FileName, true))
            {
                foreach (var item in Student.Students)
                {
                    str.WriteLine(item.ToString());
                }
            };

        }

        public IList<Student> GetAllStudents()
        {
            return Student.Students;
        }

        public Student GetStudent(int id)
        {
            Student std = default;
            foreach (var item in Student.Students)
            {
                if (item.Id == id)
                {

                    std = item;
                    break;
                }
            }
            return std;

        }
        public IList<Student> LoadContentFromFile()
        {
            // Student.Students = new List<Student>();
            try
            {
                using (var reader = new StreamReader(FileName))
                {
                    while (reader.Peek() != -1)
                    {
                        Student.Students.Add(ConvertToStudentObj(reader.ReadLine()));
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return Student.Students;
        }


        private Student ConvertToStudentObj(string st)
        {
            var data = st.Split('\t');
            var std = new Student(data[0], int.Parse(data[3]), data[1], data[2]);
            std.Id = int.Parse(data[4]);
            return std;
        }

    }
}