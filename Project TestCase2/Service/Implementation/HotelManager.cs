using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class HotelManager : IHotelManager
    {
        IRepository<Hotel> Repository = new HotelRepository();

        public void DisplayHotels(int adminId)
        {
            int count = 0;
            Console.WriteLine("Viewing all hotels: ");
            foreach (Hotel hotel in Repository.GetList(adminId))
            {
                Console.WriteLine($"{++count}. {hotel.Name}");
            }
        }

        public bool IsExist(string name)
        {
            foreach (Hotel hotel in HotelContext.Hotels)
            {
                if (hotel.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsOwner(Hotel hotel, int adminId)
        {
            if(hotel.AdminId == adminId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Register(Hotel hotel)
        {
            if (IsExist(hotel.Name))
            {
                Console.WriteLine($"Hotel with name {hotel.Name} already exists");
            }
            else
            {
                Repository.Add(hotel);
                Console.WriteLine("Hotel Registration Successfull");
            }
        }
    }
}