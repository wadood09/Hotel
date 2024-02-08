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

        public List<RoomService> GetByCustomerId(int customerId)
        {
            List<RoomService> roomServices = new();
            foreach (RoomService roomService in HotelContext.RoomServices)
            {
                if (roomService.CustomerId == customerId)
                {
                    roomServices.Add(roomService);
                }
            }
            return roomServices;
        }

        public List<RoomService> GetByHotelId(int hotelId)
        {
            List<RoomService> roomServices = new();
            foreach (RoomService roomService in HotelContext.RoomServices)
            {
                if (roomService.HotelId == hotelId)
                {
                    roomServices.Add(roomService);
                }
            }
            return roomServices;
        }

        public RoomService Get(string name, int hotelId)
        {
            foreach (RoomService roomService in HotelContext.RoomServices)
            {
                if (roomService.Name.ToLower() == name.ToLower() && roomService.HotelId == hotelId)
                {
                    return roomService;
                }
            }
            return null;
        }

        public void Remove(RoomService roomService)
        {
            HotelContext.RoomServices.Remove(roomService);
        }

        public RoomService Get(int num, int hotelId)
        {
            return GetByHotelId(hotelId)[--num];
        }
    }
}