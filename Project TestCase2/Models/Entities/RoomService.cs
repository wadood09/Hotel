namespace Project_TestCase2.Models.Entities
{
    public class RoomService : Auditables
    {
        public int HotelId {get; set;}
        public int CustomerId {get; set;}
        public string Name {get; set;}
        public double Price {get; set;}
        static int RoomServiceCount = 0;
        
        public RoomService(int hotelId, string name, double price)
        {
            Id = ++RoomServiceCount;
            HotelId = hotelId;
            Name = name;
            Price = price;
            IsDeleted = false;
        }
    }
}