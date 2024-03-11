using System.Data;
using Dapper;
using My_Dapper_Project.Context;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_Dapper_Project.Repositories.Implementation
{
    public class HotelRepository : IRepository<Hotel>
    {
        public void Add(Hotel hotel)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into Hotels 
                (Name,  AdminId, HotelStatus, Ratings) 
                values(@Name, @AdminId, @HotelStatus, @Ratings)";
                dbConnection.Execute(query, hotel);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<Hotel> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Hotels";

                return dbConnection.Query<Hotel>(query);
            }
        }

        public void Remove(Hotel hotel)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Hotels where Id = @Id";
                dbConnection.Execute(query, hotel);
            }
        }

        public void Update(Hotel hotel)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update Hotels
                Set Name = @Name,
                HotelStatus = @HotelStatus,
                Ratings = @Ratings
                where Id = @Id";
                dbConnection.Execute(query, hotel);
            }
        }
    }
}