using My_Dapper_Project.Models.Enums;

namespace My_Dapper_Project.Models.Entities
{
    public class Hotel : Auditables
    {
        public string Name {get; set;} = default!;
        public bool HasRoomService {get; set;}
        public int AdminId {get; set;}
        public Status HotelStatus {get; set;} = Status.Inactive;
        public double Ratings {get; set;}
    }
}