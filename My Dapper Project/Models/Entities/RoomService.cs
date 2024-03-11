namespace My_Dapper_Project.Models.Entities
{
    public class RoomService : Auditables
    {
        public int RoomTypeId {get; set;} = default!;
        public string Name {get; set;} = default!;
        public double Price {get; set;}
    }
}