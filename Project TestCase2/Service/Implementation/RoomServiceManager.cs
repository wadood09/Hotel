using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class RoomServiceManager : IRoomServiceManager
    {
        IRoomServiceRepository Repository = new RoomServiceRepository();

        public void DisplayNames(int hotelId)
        {
            int count = 0;
            foreach (RoomService service in Repository.GetByHotelId(hotelId))
            {
                Console.WriteLine($"{++count}. {service.Name}");
            }
        }

        public void DisplayRoomServices(int hotelId)
        {
            int count = 0;
            foreach (RoomService service in Repository.GetByHotelId(hotelId))
            {
                Console.WriteLine(++count + ". " + service.Name.PadRight(20) + $"N{service.Price:n}");
            }
        }

        public bool IsExist(string name, int hotelId)
        {
            if (Repository.Get(name, hotelId) != null)
                return true;
            else
                return false;
        }

        public bool IsExist(int num, int hotelId)
        {
            if (Repository.Get(num, hotelId) != null)
                return true;
            else
                return false;
        }
    }
}