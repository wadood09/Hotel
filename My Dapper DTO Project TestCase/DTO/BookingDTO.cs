using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;
using My_Dapper_DTO_Project_Testcase.Models.Extensions;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class BookingResponseModel : Auditables
    {
        public string Hotel { get; set; } = default!;
        public int HotelId { get; set; }
        public string RoomType { get; set; } = default!;
        public int RoomTypeId { get; set; }
        public bool IsRoomService { get; set; }
        public RoomService? RoomService { get; set; }
        public string RoomNumber { get; set; } = default!;
        public int RoomId { get; set; }
        public int CustomerID { get; set; }
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

    public class BookingResquestModel
    {
        public string Hotel { get; set; } = default!;
        public int HotelId { get; set; }
        public string RoomType { get; set; } = default!;
        public int RoomTypeId { get; set; }
        public bool IsRoomService { get; set; }
        public RoomService? RoomService { get; set; }
        public string RoomNumber { get; set; } = default!;
        public int RoomId { get; set; } = default!;
        public Status CustomerStatus { get; set; }
        public int Nights { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public double TotalPriceOfStay { get; set; }
        public bool PaidService { get; set; }
    }
}