using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Repositories.Interface
{
    public interface IRoomTypeRepository
    {
        void Add(RoomType roomType);
        void Remove(RoomType roomType);
        List<RoomType> GetAllByHotelId(int hotelId);
        List<RoomType> GetAll();
        RoomType Get(int hotelId, string name);
        RoomType Get(int hotelId, int num);
        RoomType GetById(int id);
    }
}