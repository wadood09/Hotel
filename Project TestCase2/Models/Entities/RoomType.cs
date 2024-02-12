using Project_TestCase2.Models.Enums;

namespace Project_TestCase2.Models.Entities
{
    public class RoomType : Auditables
    {
        static int RoomTypeCount = 0;
        public int HotelId {get; set;}
        public string Name {get; set;}
        public int Amount {get; set;}
        public double Price {get; set;}
        public RoomTypeStatus Status {get; set;}
        public RoomType(int hotelId, string name, int amount, double price)
        {
            Id = ++RoomTypeCount;
            HotelId = hotelId;
            Name = name;
            Amount = amount;
            Price = price;
            Status = RoomTypeStatus.Inactive;
        }
    }
}