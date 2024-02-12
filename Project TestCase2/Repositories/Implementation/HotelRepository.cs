using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class HotelRepository : IHotelRepository
    {
        public void Add(Hotel hotel)
        {
            HotelContext.Hotels.Add(hotel);
        }

        public List<Hotel> GetAll()
        {
            return HotelContext.Hotels.OrderBy(b => b.Ratings).ToList();
        }

        public Hotel GetById(int id)
        {
            return HotelContext.Hotels.FirstOrDefault(hotel => hotel.Id == id);
        }

        public Hotel GetByName(string name)
        {
            return HotelContext.Hotels.FirstOrDefault(hotel => hotel.Name.ToLower() == name.ToLower());
        }
        public Hotel GetByPos(int choice)
        {
            return GetAll()[--choice];
        }

        public List<Hotel> GetList(int adminId)
        {
            return HotelContext.Hotels.Where(hotel => hotel.AdminId == adminId).ToList();
        }

        public void Remove(Hotel hotel)
        {
            HotelContext.Hotels.Remove(hotel);
        }
    }
}