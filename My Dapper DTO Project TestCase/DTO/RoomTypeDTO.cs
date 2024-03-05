using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class RoomTypeResponseModel : Auditables
    {
        public int HotelId {get; set;}
        public string Name {get; set;} = default!;
        public int AmountOfRooms {get; set;}
        public double Price {get; set;}
        public Status Status {get; set;}
    }

    public class RoomTypeRequestModel
    {
        public int HotelId {get; set;}
        public string Name {get; set;} = default!;
        public int AmountOfRooms {get; set;}
        public double Price {get; set;}
        public List<string> RoomNumbers {get; set;} = default!;
    }
}