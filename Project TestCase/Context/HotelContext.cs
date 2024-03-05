using My_File_Project.Models.Entities;

namespace My_File_Project.Context
{
    public class HotelContext
    {
        public static List<Admin> Admins = new();
        public static List<Booking> Bookings = new();
        public static List<Customer> Customers = new();
        public static List<Hotel> Hotels = new();
        public static List<Room> Rooms = new();
        public static List<RoomService> RoomServices = new();
        public static List<RoomType> RoomTypes = new();
        public static List<User> Users = new();



        public static string AdminFile = "Files\\Admins.txt";
        public static string BookingFile = "Files\\Bookings.txt";
        public static string CustomerFile = "Files\\Customers.txt";
        public static string HotelFile = "Files\\Hotels.txt";
        public static string RoomFile = "Files\\Rooms.txt";
        public static string RoomServiceFile = "Files\\RoomServices.txt";
        public static string RoomTypeFile = "Files\\RoomTypes.txt";
        public static string UserFile = "Files\\Users.txt";
    }
}