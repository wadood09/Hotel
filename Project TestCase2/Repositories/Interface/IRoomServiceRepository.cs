using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Repositories.Interface
{
    public interface IRoomServiceRepository
    {
        void Add(RoomService roomService);
        void Remove(RoomService roomService);
        List<RoomService> GetByHotelId(int hotelId);
        RoomService GetByName(string name, int hotelId);
        List<RoomService> GetByCustomerId(int customerId);
    }
}