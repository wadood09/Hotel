using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;

namespace My_Dapper_DTO_Project_Testcase.Repositories.Implementation
{
    public class AdminRepository : IRepository<Admin>
    {
        private readonly string _connectionString;
        public AdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Admin admin)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Insert into Admins (UserEmail) values(@UserEmail)";
                dbConnection.Execute(query, admin);
            }
        }

        public IEnumerable<Admin> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Select * from Admins";

                return dbConnection.Query<Admin>(query);
            }
        }

        public void Remove(Admin admin)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from Admins where Id = @Id";
                dbConnection.Execute(query, admin);
            }
        }

        public void Update(Admin admin)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Update Admins 
                Set UserEmail = @UserEmail
                Where Id = @Id";
                dbConnection.Execute(query, admin);
            }
        }
    }
}