using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;

namespace My_Dapper_DTO_Project_Testcase.Repositories.Implementation
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

        public void Update(RoomService service)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Update RoomServices
                Set Name = @Name,
                HotelId = @HotelId,
                Price = @Price
                where Id = @Id";
                dbConnection.Execute(query, service);
            }
        }
    }
}