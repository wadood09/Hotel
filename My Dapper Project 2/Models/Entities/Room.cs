using My_Dapper_Project_2.Models.Enums;

namespace My_Dapper_Project_2.Models.Entities
{
    public class Room : Auditables
    {
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = default!;
        public RoomStatus RoomStatus { get; set; } = RoomStatus.Vacant;
    }
}