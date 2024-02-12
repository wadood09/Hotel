using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public void Add(RoomType roomType)
        {
            HotelContext.RoomTypes.Add(roomType);
        }

        public RoomType Get(int hotelId, string name)
        {
            return HotelContext.RoomTypes.FirstOrDefault(roomType => roomType.HotelId == hotelId && roomType.Name.ToLower() == name.ToLower());
        }

        public RoomType Get(int hotelId, int num)
        {
            if (num > GetAllByHotelId(hotelId).Count || num < 1)
                return null;
            else
                return GetAllByHotelId(hotelId)[--num];
        }

        public List<RoomType> GetAll()
        {
            return HotelContext.RoomTypes;
        }

        public List<RoomType> GetAllByHotelId(int hotelId)
        {
            return HotelContext.RoomTypes.Where(type => type.HotelId == hotelId).ToList();
        }

        public RoomType GetById(int id)
        {
            return HotelContext.RoomTypes.FirstOrDefault(type => type.Id == id);
        }

        public void Remove(RoomType roomType)
        {
            HotelContext.RoomTypes.Remove(roomType);
        }
    }
}