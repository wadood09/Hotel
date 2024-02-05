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

        public List<Room> GetRooms(int customerId)
        {
            List<Room> rooms = new();
            foreach (Room room in HotelContext.Rooms)
            {
                if(room.CustomerId == customerId)
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public List<Room> GetByRoomTypeId(int roomTypeId)
        {
            List<Room> rooms = new();
            foreach (Room room in HotelContext.Rooms)
            {
                if(room.RoomTypeId == roomTypeId)
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public Room GetByRoomNumber(string roomNumber, int roomTypeId)
        {
            foreach (Room room in HotelContext.Rooms)
            {
                if(room.Number == roomNumber && room.RoomTypeId == roomTypeId)
                {
                    return room;
                }
            }
            return null;
        }

        public void Remove(Room room)
        {
            HotelContext.Rooms.Remove(room);
        }
    }
}