using System.Data;
using Dapper;
using My_Dapper_Project_2.Context;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Interface;

namespace My_Dapper_Project_2.Repositories.Implementation
{
    public class RoomServiceRepository : IRepository<RoomService>
    {
        public void Add(RoomService service)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into RoomServices 
                (HotelId, Name, Price) 
                values(@HotelId, @Name, @Price)";
                dbConnection.Execute(query, service);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<RoomService> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from RoomServices";

                return dbConnection.Query<RoomService>(query);
            }
        }

        public void Remove(RoomService service)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from RoomServices where Id = @Id";
                dbConnection.Execute(query, service);
            }
        }

        public void Update(RoomService service)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
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