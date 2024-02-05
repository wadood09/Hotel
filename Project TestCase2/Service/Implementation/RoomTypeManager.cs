using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class RoomTypeManager : IRoomTypeManager
    {
        IRoomTypeRepository Repository = new RoomTypeRepository();

        public void DisplayRoomTypes(int hotelId)
        {
            foreach (RoomType type in Repository.GetAll(hotelId))
            {
                Console.WriteLine($"{type.Name}     N{type.Price:n}     {type.Status}");
            }
        }

        public bool IsExist(string name, int hotelId)
        {
            if(Repository.Get(hotelId, name) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}