using System.Text.Json;
using My_File_Project.Context;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class BookingRepository : IRepository<Booking>
    {
        public void Add(Booking booking)
        {
            HotelContext.Bookings.Add(booking);

            using (StreamWriter writer = new(HotelContext.BookingFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(booking));
            }
        }

        public Booking? Get(Func<Booking, bool> pred)
        {
            Booking? booking = HotelContext.Bookings.SingleOrDefault(pred);
            return booking;
        }

        public List<Booking> GetAll()
        {
            return HotelContext.Bookings;
        }

        public List<Booking> GetSelected(Func<Booking, bool> pred)
        {
            return HotelContext.Bookings.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.BookingFile, false))
            {
                foreach (Booking booking in HotelContext.Bookings)
                {
                    writer.WriteLine(JsonSerializer.Serialize(booking));
                }
            }
        }

        public void RefreshList()
        {
            string[] bookings = File.ReadAllLines(HotelContext.BookingFile);
            foreach (string booking in bookings)
            {
                HotelContext.Bookings.Add(JsonSerializer.Deserialize<Booking>(booking)!);
            }
        }

        public void Remove(Booking booking)
        {
            HotelContext.Bookings.Remove(booking);

            RefreshFile();
        }
    }
}