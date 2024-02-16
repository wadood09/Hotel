using Project_TestCase2.Models.Entities;
using Project_TestCase2.Models.Extensions;
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
            Console.WriteLine("Viewing all room types: ");
            foreach (RoomType type in Repository.GetAllByHotelId(hotelId))
            {
                Console.WriteLine(type.Name.ToPascalCase().PadRight(20) + $"N{type.Price:n}".PadRight(30) + type.Status);
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