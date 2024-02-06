using Project_TestCase2.Models.Enums;

namespace Project_TestCase2.Models.Entities
{
    public class Room : Auditables
    {
        static int RoomCount = 0;
        public int RoomTypeId {get; set;}
        public int CustomerId {get; set;}
        public string Number {get; set;}
        public RoomStatus RoomStatus {get; set;}

        public Room(int roomTypeId, string number)
        {
            Id = ++RoomCount;
            RoomTypeId = roomTypeId;
            Number = number;
            RoomStatus = RoomStatus.Vacant;
        }
    }
}