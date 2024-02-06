using Project_TestCase2.Models.Enums;

namespace Project_TestCase2.Models.Entities
{
    public class Hotel : Auditables
    {
        public string Name {get; set;}
        public bool RoomService {get; set;}
        public int AdminId {get; set;}
        public HotelStatus HotelStatus {get; set;} 
        public double Ratings {get; set;}
        public double EarlyCheckOutFee {get; set;}

        static int HotelCount = 0;

        public Hotel(int adminId, string name, bool roomService, double checkOutFee)
        {
            Name = name;
            AdminId = adminId;
            RoomService = roomService;
            EarlyCheckOutFee = checkOutFee;
            HotelStatus = HotelStatus.Active;
            Id = ++HotelCount;
        }
    }
}