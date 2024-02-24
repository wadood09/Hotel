using My_Dapper_Project.Models.Enums;

namespace My_Dapper_Project.Models.Entities
{
    public class RoomType : Auditables
    {
        public string? HotelId {get; set;}
        public string? Name {get; set;}
        public int AmountOfRooms {get; set;}
        public double Price {get; set;}
        public Status Status {get; set;} = Status.Inactive;
    }
}