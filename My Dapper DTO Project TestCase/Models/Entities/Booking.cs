using System.Text;
using My_Dapper_DTO_Project_Testcase.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;
using My_Dapper_DTO_Project_Testcase.Models.Extensions;

namespace My_Dapper_DTO_Project_Testcase.Models.Entities
{
    public class Booking : Auditables
    {
        public string Hotel { get; set; } = default!;
        public int HotelId { get; set; }
        public string RoomType { get; set; } = default!;
        public int RoomTypeId { get; set; }
        public bool IsRoomService { get; set; }
        public RoomService? RoomService { get; set; }
        public string RoomNumber { get; set; } = default!;
        public int RoomId { get; set; }
        public string CustomerID { get; set; } = default!;
        public Status CustomerStatus { get; set; }
        public int Nights { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public double TotalPriceOfStay { get; set; }
        public bool Rate { get; set; } = false;
        public bool PaidService { get; set; }

        public override string ToString()
        {
            StringBuilder service = new();
            service.Append($"HasRoomService: {IsRoomService,-15}");
            if (IsRoomService)
            {
                
                service.Append($" Type: {RoomService!.Name!.ToPascalCase()}");
            }
            return @$"Hotel Name: {Hotel}
            {service}
            RoomType: {RoomType!.ToPascalCase(),-20}  RoomNumber: {RoomNumber}";
        }
    }
}