using System.Data;
using Dapper;
using My_Dapper_Project_2.Context;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Interface;

namespace My_Dapper_Project_2.Repositories.Implementation
{
    public class WalletRepository : IRepository<Wallet>
    {
        public void Add(Wallet wallet)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into Wallets 
                (WalletBalance) 
                values(@WalletBalance)";
                dbConnection.Execute(query, wallet);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<Wallet> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Wallets";

                return dbConnection.Query<Wallet>(query);
            }
        }

        public void Remove(Wallet wallet)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Wallets where Id = @Id";
                dbConnection.Execute(query, wallet);
            }
        }

        public void Update(Wallet wallet)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update Wallets
                Set WalletBalance = @WalletBalance
                where Id = @Id";
                dbConnection.Execute(query, wallet);
            }
        }
    }
}