namespace My_Dapper_Project_2.Models.Entities
{
    public class RoomService : Auditables
    {
        public int HotelId {get; set;} = default!;
        public string Name {get; set;} = default!;
        public double Price {get; set;}
    }
}