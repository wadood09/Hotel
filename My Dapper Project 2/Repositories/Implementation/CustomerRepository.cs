using System.Data;
using Dapper;
using My_Dapper_Project_2.Context;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Interface;

namespace My_Dapper_Project_2.Repositories.Implementation
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add(Customer customer)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Insert into Customers (UserEmail) values(@UserEmail)";
                dbConnection.Execute(query, customer);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<Customer> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Customers";

                return dbConnection.Query<Customer>(query);
            }
        }

        public void Remove(Customer customer)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Customers where Id = @Id";
                dbConnection.Execute(query, customer);
            }
        }

        public void Update(Customer customer)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Update Customers set UserEmail = @UserEmail where Id = @Id";
                dbConnection.Execute(query, customer);
            }
        }
    }
}