using System.Data;
using Dapper;
using My_Dapper_Project_2.Context;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Interface;

namespace My_Dapper_Project_2.Repositories.Implementation
{
    public class RoomTypeRepository : IRepository<RoomType>
    {
        public void Add(RoomType type)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into RoomTypes 
                (HotelId, Name, AmountOfRooms, Price, Status) 
                values(@HotelId, @Name, @AmountOfRooms, @Price, @Status)";
                dbConnection.Execute(query, type);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<RoomType> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from RoomTypes";

                return dbConnection.Query<RoomType>(query);
            }
        }

        public void Remove(RoomType type)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from RoomTypes where Id = @Id";
                dbConnection.Execute(query, type);
            }
        }

        public void Update(RoomType type)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update RoomTypes
                Set Name = @Name,
                HotelId = @HotelId,
                AmountOfRooms = @AmountOfRooms,
                Status = @Status,
                Price = @Price
                where Id = @Id";
                dbConnection.Execute(query, type);
            }
        }
    }
}