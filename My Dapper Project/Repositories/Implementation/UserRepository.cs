using System.Data;
using Dapper;
using My_Dapper_Project.Context;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_Dapper_Project.Repositories.Implementation
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User user)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into Users 
                (FirstName, LastName, Dob, Wallet, Email, Password, Role) 
                values (@FirstName, @LastName, @Dob, @Wallet, @Email, @Password, @Role)";
                dbConnection.Execute(query, user);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Users";

                return dbConnection.Query<User>(query);
            }
        }

        public void Remove(User user)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Users where Email = @Email";
                dbConnection.Execute(query, user);
            }
        }

        public void Update(User user)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update Users
                Set FirstName = @FirstName,
                LastName = @LastName,
                Dob = @Dob,
                Wallet = @Wallet,
                Password = @Password
                where Email = @Email";
                dbConnection.Execute(query, user);
            }
        }
    }
}