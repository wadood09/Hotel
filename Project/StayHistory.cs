class StayHistory
{
    public string Hotel {get; set;}
    public int HotelID {get; set;}
    public string RoomType {get; set;}
    public int RoomID {get; set;}
    public bool RoomService {get; set;}
    public int RoomNumber {get; set;}
    public int CustomerID {get; set;}
    public int StayPeriod {get; set;}
    public DateTime CheckInDate {get; set;}
    public DateTime CheckOutDate {get; set;}
    public bool Rate {get; set;}
    public StayHistory(string hotel, int hotelId, string roomType, int roomId, bool roomService, int roomNumber, int customerId, int nights)
    {
        Hotel = hotel;
        HotelID = hotelId;
        RoomType = roomType;
        RoomID = roomId;
        RoomService = roomService;
        RoomNumber = roomNumber;
        CustomerID = customerId;
        StayPeriod = nights;
        CheckInDate = DateTime.Now;
        CheckOutDate = DateTime.Now.AddDays(nights);
    }
}