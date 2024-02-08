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
            foreach (RoomType roomType in HotelContext.RoomTypes)
            {
                if(roomType.HotelId == hotelId && roomType.Name.ToLower() == name.ToLower())
                {
                    return roomType;
                }
            }
            return null;
        }
        
        public RoomType Get(int hotelId, int num)
        {
            return GetAllByHotelId(hotelId)[--num];
        }

        public List<RoomType> GetAll()
        {
            return HotelContext.RoomTypes;
        }

        public List<RoomType> GetAllByHotelId(int hotelId)
        {
            List<RoomType> roomTypes = new();
            foreach (RoomType roomType in HotelContext.RoomTypes)
            {
                if(roomType.HotelId == hotelId)
                {
                    roomTypes.Add(roomType);
                }
            }
            return roomTypes;
        }

        public RoomType GetById(int id)
        {
            foreach (RoomType roomType in HotelContext.RoomTypes)
            {
                if(roomType.Id == id)
                {
                    return roomType;
                }
            }
            return null;
        }

        public void Remove(RoomType roomType)
        {
            HotelContext.RoomTypes.Remove(roomType);
        }
    }
}