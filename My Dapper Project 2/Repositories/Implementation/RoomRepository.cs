using System.Data;
using Dapper;
using My_Dapper_Project_2.Context;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Interface;

namespace My_Dapper_Project_2.Repositories.Implementation
{
    public class RoomRepository : IRepository<Room>
    {
        public void Add(Room room)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Insert into Rooms 
                (RoomTypeId, RoomNumber, RoomStatus) 
                values(@RoomTypeId, @RoomNumber, @RoomStatus)";
                dbConnection.Execute(query, room);
            }
        }

        public IDbConnection Connection()
        {
            return HotelContext.Connection();
        }

        public IEnumerable<Room> GetAll()
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Select * from Rooms";

                return dbConnection.Query<Room>(query);
            }
        }

        public void Remove(Room room)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = "Delete from Rooms where Id = @Id";
                dbConnection.Execute(query, room);
            }
        }

        public void Update(Room room)
        {
            using (IDbConnection dbConnection = HotelContext.Connection())
            {
                string query = @"Update Rooms
                Set RoomTypeId = @RoomTypeId,
                RoomNumber = @RoomNumber,
                RoomStatus = @RoomStatus
                where Id = @Id";
                dbConnection.Execute(query, room);
            }
        }
    }
}