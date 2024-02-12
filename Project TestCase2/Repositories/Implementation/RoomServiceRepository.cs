using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class RoomServiceRepository : IRoomServiceRepository
    {
        public void Add(RoomService roomService)
        {
            HotelContext.RoomServices.Add(roomService);
        }

        public List<RoomService> GetByHotelId(int hotelId)
        {
            return HotelContext.RoomServices.Where(service => service.HotelId == hotelId).ToList();
        }

        public RoomService Get(string name, int hotelId)
        {
            return HotelContext.RoomServices.FirstOrDefault(service => service.Name.ToLower() == name.ToLower() && service.HotelId == hotelId);
        }

        public void Remove(RoomService roomService)
        {
            HotelContext.RoomServices.Remove(roomService);
        }

        public RoomService Get(int num, int hotelId)
        {
            if (num > GetByHotelId(hotelId).Count || num < 1)
                return null;
            else
                return GetByHotelId(hotelId)[--num];
        }
    }
}