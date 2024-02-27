using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_Dapper_Project.Repositories.Implementation
{
    public class HotelRepository : IRepository<Hotel>
    {
        private readonly string _connectionString;
        public HotelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Hotel hotel)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Insert into Hotels 
                (Name, HasRoomService, AdminId, HotelStatus, Ratings) 
                values(@Name, @HasRoomService, @AdminId, @HotelStatus, @Ratings)";
                dbConnection.Execute(query, hotel);
            }
        }

        public IEnumerable<Hotel> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Select * from Hotels";

                return dbConnection.Query<Hotel>(query);
            }
        }

        public void Remove(Hotel hotel)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from Hotels where Id = @Id";
                dbConnection.Execute(query, hotel);
            }
        }

        public void Update(Hotel hotel)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Update Hotels
                Set Name = @Name,
                HasRoomService = @HasRoomService,
                AdminId = @AdminId,
                HotelStatus = @HotelStatus,
                Ratings = @Ratings
                where Id = @Id";
                dbConnection.Execute(query, hotel);
            }
        }
    }
}