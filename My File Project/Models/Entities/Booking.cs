using System.Text;
using My_File_Project.Entities;
using My_File_Project.Models.Enums;
using My_File_Project.Models.Extensions;

namespace My_File_Project.Models.Entities
{
    public class Booking : Auditables
    {
        public string? Hotel { get; set; }
        public string? HotelId { get; set; }
        public string? RoomType { get; set; }
        public string? RoomTypeId { get; set; }
        public bool IsRoomService { get; set; }
        public RoomService? RoomService { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomId { get; set; }
        public string? CustomerID { get; set; }
        public Status CustomerStatus { get; set; }
        public int Nights { get; set; }
        public DatePeriod StayPeriod { get; set; }
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