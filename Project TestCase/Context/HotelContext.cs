using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Context
{
    public class HotelContext
    {
        public static List<Customer> Customers = new();
        public static List<Hotel> Hotels = new();
        public static List<Admin> Admins = new();
        public static List<Room> Rooms = new();
        public static List<RoomService> RoomServices = new();
        public static List<RoomType> RoomTypes = new();
        public static List<StayHistory> StayHistories = new();    }
}