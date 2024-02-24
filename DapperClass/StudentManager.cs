
using Dapper;
using MySql.Data.MySqlClient;

namespace DapperClass
{
    public class StudentManager : IStudentManager
    {
        const string connectionString ="Server=localhost;Database = studentdb;User ID=root;Password=Adelesi";
        public Student Create(Student std)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Execute("Insert Into Student (Name , Email) Values (@Name , @Email)", std);
                    return std;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Student>("Select * from Student where Id = @Id", new {Id = id}).First();
            }
        }

        public IList<Student> GetAll()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Student>("Select * from Student").ToList();
            }
        }

        public void SetUp()
        {
            try 
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var databaseName = "StudentDb";
                    connection.Open();
                    // connection.Execute("Create Schema StudentDb");
                    // connection.Execute("Use Databse StudentDb");
                    connection.Execute("Create table Student (Id int primary key auto_increment , Name varchar(200), Email varchar(200))");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Student Update(Student std)
        {
            throw new NotImplementedException();
        }
    }
}