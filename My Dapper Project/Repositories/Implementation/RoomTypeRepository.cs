using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class RoomTypeRepository : IRepository<RoomType>
    {
        private readonly string _connectionString;
        public RoomTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(RoomType type)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Insert into RoomTypes 
                (HotelId, Name, AmountOfRooms, Price, Status) 
                values(@HotelId, @Name, @AmountOfRooms, @Price, @Status)";
                dbConnection.Execute(query, type);
            }
        }

        public IEnumerable<RoomType> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Select * from RoomTypes";

                return dbConnection.Query<RoomType>(query);
            }
        }

        public void Remove(RoomType type)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from RoomTypes where Id = @Id";
                dbConnection.Execute(query, type);
            }
        }
    }
}