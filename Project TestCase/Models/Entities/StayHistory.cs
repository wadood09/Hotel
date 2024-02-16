using Project_TestCase2.Models.Enums;

namespace Project_TestCase2.Models.Entities
{
    public class StayHistory
    {
        public string Hotel { get; set; }
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public double Price { get; set; }
        public bool IsRoomService { get; set; }
        public RoomService RoomService { get; set; }
        public string RoomNumber { get; set; }
        public int CustomerID { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
        public int StayPeriod { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalPriceOfStay { get; set; }
        public bool Rate { get; set; }
        public StayHistory(string hotel, int hotelId,string roomType, int roomTypeId, double price, bool isRoomService, RoomService roomService, string roomNumber, int customerId, int nights, int date)
        {
            Hotel = hotel;
            HotelId = hotelId;
            RoomType = roomType;
            RoomTypeId = roomTypeId;
            Price = price;
            IsRoomService = isRoomService;
            RoomService = roomService;
            RoomNumber = roomNumber;
            CustomerID = customerId;
            CustomerStatus = CustomerStatus.CheckedIn;
            StayPeriod = nights;
            CheckInDate = DateTime.Now.AddDays(date);
            CheckOutDate = CheckInDate.AddDays(nights);
            TotalPriceOfStay = price * nights;
            if (isRoomService)
            {
                TotalPriceOfStay += roomService.Price;
            }
        }
    }
}