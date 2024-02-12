using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Repositories.Interface
{
    public interface IRoomRepository
    {
        void Add(Room value);
        void Remove(Room value);
        List<Room> GetByRoomTypeId(int roomTypeId);
        List<Room> GetByHotelId(int hotelId);
        Room GetByRoomNumber(string roomNumber, int roomTypeId);
    }
}