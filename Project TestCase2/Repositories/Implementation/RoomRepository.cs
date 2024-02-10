using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class RoomRepository : IRoomRepository
    {
        public void Add(Room room)
        {
            HotelContext.Rooms.Add(room);
        }

        public List<Room> GetByRoomTypeId(int roomTypeId)
        {
            return HotelContext.Rooms.Where(room => room.RoomTypeId == roomTypeId).ToList();
        }

        public Room GetByRoomNumber(string roomNumber, int roomTypeId)
        {
            return HotelContext.Rooms.FirstOrDefault(room => room.Number == roomNumber && room.RoomTypeId == roomTypeId);
        }

        public void Remove(Room room)
        {
            HotelContext.Rooms.Remove(room);
        }
    }
}