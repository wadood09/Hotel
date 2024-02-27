using My_Dapper_DTO_Project_Testcase.Models.Enums;

namespace My_Dapper_DTO_Project_Testcase.Models.Entities
{
    public class RoomType : Auditables
    {
        public int HotelId {get; set;}
        public string? Name {get; set;}
        public int AmountOfRooms {get; set;}
        public double Price {get; set;}
        public Status Status {get; set;} = Status.Inactive;
    }
}