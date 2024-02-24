using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class RoomServiceRepository : IRepository<RoomService>
    {
        private readonly string _connectionString;
        public RoomServiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(RoomService service)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Insert into RoomServices 
                (HotelId, Name, Price) 
                values(@HotelId, @Name, @Price)";
                dbConnection.Execute(query, service);
            }
        }

        public IEnumerable<RoomService> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Select * from RoomServices";

                return dbConnection.Query<RoomService>(query);
            }
        }

        public void Remove(RoomService service)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from RoomServices where Id = @Id";
                dbConnection.Execute(query, service);
            }
        }
    }
}