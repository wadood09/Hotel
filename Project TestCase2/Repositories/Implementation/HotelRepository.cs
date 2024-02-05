using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class HotelRepository : IRepository<Hotel>
    {
        public void Add(Hotel hotel)
        {
            HotelContext.Hotels.Add(hotel);
        }

        public List<Hotel> GetAll()
        {
            return HotelContext.Hotels;//.Sort(b => b.Ratings);
        }

        public Hotel GetById(int id)
        {
            foreach (Hotel hotel in HotelContext.Hotels)
            {
                if(hotel.Id == id)
                {
                    return hotel;
                }
            }
            return null;
        }

        public Hotel GetByName(string name)
        {
            foreach (Hotel hotel in HotelContext.Hotels)
            {
                if(hotel.Name.ToLower() == name.ToLower())
                {
                    return hotel;
                }
            }
            return null;
        }

        public List<Hotel> GetList(int id)
        {
            List<Hotel> hotels = new();
            foreach (Hotel hotel in HotelContext.Hotels)
            {
                if(hotel.AdminId == id)
                {
                    hotels.Add(hotel);
                }
            }
            return hotels;
        }

        public void Remove(Hotel hotel)
        {
            HotelContext.Hotels.Remove(hotel);
        }
    }
}