using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class UserRepository : IRepository<User>
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(User user)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Insert into Users 
                (FirstName, LastName, Dob, Wallet, Email, Password, Role) 
                values (@FirstName, @LastName, @Dob, @Wallet, @Email, @Password, @Role)";
                dbConnection.Execute(query, user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Select * from Users";

                return dbConnection.Query<User>(query);
            }
        }

        public void Remove(User user)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from Users where Id = @Id";
                dbConnection.Execute(query, user);
            }
        }
    }
}