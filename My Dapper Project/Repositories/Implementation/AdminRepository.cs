using System.Data;
using Dapper;
using My_Dapper_Project.Context;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_Dapper_Project.Repositories.Implementation
{
    public class AdminRepository : IRepository<Admin>
    {
        public void Add(Admin admin)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Insert into Admins (UserEmail) values(@UserEmail)";
                dbConnection.Execute(query, admin);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<Admin> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Admins";

                return dbConnection.Query<Admin>(query);
            }
        }

        public void Remove(Admin admin)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Admins where Id = @Id";
                dbConnection.Execute(query, admin);
            }
        }

        public void Update(Admin admin)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update Admins 
                Set UserEmail = @UserEmail
                Where Id = @Id";
                dbConnection.Execute(query, admin);
            }
        }
    }
}