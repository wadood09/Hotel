public class Hotel : Room
{
    public static int HotelCount = 0;
    public string Name { get; set; }
    public bool RoomService { get; set; }
    public double RoomServicePrice { get; set; }
    public double Ratings { get; set; }
    public  int ID {get; set;}
    public int AdminId {get; set;}

    public Hotel(string name, List<string> roomTypes, List<RoomStatus> roomStatuses, List<double> roomPrices, List<int> amountOfRoomTypes,int roomNumber, bool roomService, double roomServicePrice, int adminId)
    {
        ID = HotelCount + 1;
        Name = name;
        RoomTypes = roomTypes;
        RoomStatuses = roomStatuses;
        RoomPrices = roomPrices;
        RoomService = roomService;
        RoomServicePrice = roomServicePrice;
        AmountOfRoomsTypes = amountOfRoomTypes;
        StartingNumber = roomNumber;
        AdminId = adminId;
        HotelCount++;
    }
}