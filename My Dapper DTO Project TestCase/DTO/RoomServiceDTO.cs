using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class RoomServiceResponseModel : Auditables
    {
        public string HotelId {get; set;} = default!;
        public string Name {get; set;} = default!;
        public double Price {get; set;}
    }

    public class RoomServiceRequestModel : Auditables
    {
        public string HotelId {get; set;} = default!;
        public string Name {get; set;} = default!;
        public double Price {get; set;}
    }
}