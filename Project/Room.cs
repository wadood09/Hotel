public abstract class Room
{
    public List<string> RoomTypes {get; set;}
    public List<double> RoomPrices {get; set;}
    public List<int> AmountOfRoomsTypes {get; set;}
    public List<int> RoomNumber {get; set;}
    public int StartingNumber {get; set;}
    public List<RoomStatus> RoomStatuses {get;set;}
}