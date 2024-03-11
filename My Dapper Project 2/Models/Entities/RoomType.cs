using My_Dapper_Project_2.Models.Enums;

namespace My_Dapper_Project_2.Models.Entities
{
    public class RoomType : Auditables
    {
        public int HotelId {get; set;}
        public string Name {get; set;} = default!;
        public int AmountOfRooms {get; set;}
        public double Price {get; set;}
        public Status Status {get; set;} = Status.Inactive;
    }
}