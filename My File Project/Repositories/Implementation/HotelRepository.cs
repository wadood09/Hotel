using System.Text.Json;
using My_File_Project.Context;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class HotelRepository : IRepository<Hotel>
    {
        public void Add(Hotel hotel)
        {
            HotelContext.Hotels.Add(hotel);

            using (StreamWriter writer = new(HotelContext.HotelFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(hotel));
            }
        }

        public Hotel? Get(Func<Hotel, bool> pred)
        {
            Hotel? hotel = HotelContext.Hotels.SingleOrDefault(pred);
            return hotel;
        }

        public List<Hotel> GetAll()
        {
            return HotelContext.Hotels;
        }

        public List<Hotel> GetSelected(Func<Hotel, bool> pred)
        {
            return HotelContext.Hotels.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.HotelFile, false))
            {
                foreach (Hotel hotel in HotelContext.Hotels)
                {
                    writer.WriteLine(JsonSerializer.Serialize(hotel));
                }
            }
        }

        public void RefreshList()
        {
            string[] hotels = File.ReadAllLines(HotelContext.HotelFile);
            foreach (string hotel in hotels)
            {
                HotelContext.Hotels.Add(JsonSerializer.Deserialize<Hotel>(hotel)!);
            }
        }
    }
}