using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AdoClass
{
    public class StudentManager : IStudentManager
    {
        string connectionString = "Server=localhost;Database=Student;User ID=root;Password=Adelesi";

        public StudentManager()
        {
        }

        public Student AddStudent(Student std)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var sqlCommand = new MySqlCommand($"insert into student (name,age,email,address) values ('{std.Name}',{std.Age}, '{std.Email}', '{std.Address}')", sqlConnection);
                    var affectedRows = sqlCommand.ExecuteNonQuery();
                    if(affectedRows > 0)
                    {
                        Console.WriteLine("Student registered");
                    }
                    else
                    {
                        Console.WriteLine("Error");

                    }

                };
            }
            catch
            {

            }
            return std;

        }

        public void DeleteStudent(int id)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var sqlCommand = new MySqlCommand($"Delete from student where id = {id}", sqlConnection);
                    var affectedRows = sqlCommand.ExecuteNonQuery();
                    if(affectedRows > 0)
                    {
                        Console.WriteLine("Student registered");
                    }
                    else
                    {
                        Console.WriteLine("Error");

                    }

                };
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public void UpdateStudent(int id , string Name)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var sqlCommand = new MySqlCommand($"update student set Name = '{Name}' where id= {id}", sqlConnection);
                    var affectedRows = sqlCommand.ExecuteNonQuery();
                    if(affectedRows > 0)
                    {
                        Console.WriteLine("Student registered");
                    }
                    else
                    {
                        Console.WriteLine("Error");

                    }

                };
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public IList<Student> GetAllStudents()
        {
            var list = new List<Student>();
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var sqlCommand = new MySqlCommand($"select * from student", sqlConnection);
                    var reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        var student = new Student(reader["name"].ToString(), int.Parse(reader["age"].ToString()), reader["email"].ToString(), reader["address"].ToString());
                        student.Id = int.Parse(reader["id"].ToString());

                        list.Add(student);
                    }

                };
            }
            catch (SqlTypeException )
            {

            }
            catch (System.Exception)
            {
                
                throw;
            }
            return list;
        }

        public Student GetStudent(int id)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var sqlCommand = new MySqlCommand($"select * from student where id={id}", sqlConnection);
                    var reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        var student = new Student(reader["name"].ToString(), int.Parse(reader["age"].ToString()), reader["email"].ToString(), reader["address"].ToString());
                        student.Id = int.Parse(reader["id"].ToString());
                        return student;

                    }

                };
            }
            catch (SqlTypeException )
            {

            }
            catch (System.Exception)
            {
                
                throw;
            }
            return null;

        }
        

    }
}