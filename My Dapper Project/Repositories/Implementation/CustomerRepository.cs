using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_Dapper_Project.Repositories.Implementation
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly string _connectionString;
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Customer customer)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Insert into Customers (UserEmail) values(@UserEmail)";
                dbConnection.Execute(query, customer);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Select * from Customers";

                return dbConnection.Query<Customer>(query);
            }
        }

        public void Remove(Customer customer)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from Customers where Id = @Id";
                dbConnection.Execute(query, customer);
            }
        }

        public void Update(Customer customer)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Update Customers set UserEmail = @UserEmail where Id = @Id";
                dbConnection.Execute(query, customer);
            }
        }
    }
}