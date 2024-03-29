using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;

namespace My_Dapper_DTO_Project_Testcase.Repositories.Implementation
{
    public class RoomRepository : IRepository<Room>
    {
        private readonly string _connectionString;
        public RoomRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Room room)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Insert into Rooms 
                (HotelId, RoomTypeId, Number, RoomStatus) 
                values(@HotelId, @RoomTypeId, @Number, @RoomStatus)";
                dbConnection.Execute(query, room);
            }
        }

        public IEnumerable<Room> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Select * from Rooms";

                return dbConnection.Query<Room>(query);
            }
        }

        public void Remove(Room room)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from Rooms where Id = @Id";
                dbConnection.Execute(query, room);
            }
        }

        public void Update(Room room)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Update Rooms
                Set HotelId = @HotelId,
                RoomTypeId = @RoomTypeId,
                Number = @Number,
                RoomStatus = @RoomStatus,
                where Id = @Id";
                dbConnection.Execute(query, room);
            }
        }
    }
}