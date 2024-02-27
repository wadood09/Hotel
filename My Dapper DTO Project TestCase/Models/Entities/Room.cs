using My_Dapper_DTO_Project_Testcase.Models.Enums;

namespace My_Dapper_DTO_Project_Testcase.Models.Entities
{
    public class Room : Auditables
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public string Number { get; set; } = default!;
        public RoomStatus RoomStatus { get; set; } = RoomStatus.Vacant;
    }
}