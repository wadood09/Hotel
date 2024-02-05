namespace Project_TestCase2.Models.Entities
{
    public class StayHistory
    {
        public string Hotel { get; set; }
        public int HotelID { get; set; }
        public string RoomType { get; set; }
        public int RoomTypeID { get; set; }
        public bool RoomService { get; set; }
        public string RoomServiceType { get; set; }
        public int RoomNumber { get; set; }
        public int CustomerID { get; set; }
        public int StayPeriod { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool Rate { get; set; }
        public StayHistory(string hotel, int hotelId, string roomType, int roomTypeId, bool roomService, string roomServiceType, int roomNumber, int customerId, int nights)
        {
            Hotel = hotel;
            HotelID = hotelId;
            RoomType = roomType;
            RoomTypeID = roomTypeId;
            RoomService = roomService;
            RoomServiceType = roomServiceType;
            RoomNumber = roomNumber;
            CustomerID = customerId;
            StayPeriod = nights;
        }
    }
}