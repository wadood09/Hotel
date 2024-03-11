using My_Dapper_Project_2.Models.Enums;

namespace My_Dapper_Project_2.Models.Entities
{
    public class Hotel : Auditables
    {
        public string Name {get; set;} = default!;
        public int AdminId {get; set;}
        public Status HotelStatus {get; set;} = Status.Inactive;
        public double Ratings {get; set;}
    }
}