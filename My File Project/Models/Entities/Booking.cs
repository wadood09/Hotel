using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Entities;
using My_File_Project.Models.Enums;

namespace My_File_Project.Models.Entities
{
    public class Booking : Auditables
    {
        public string? Hotel { get; set; }
        public string? HotelId { get; set; }
        public string? RoomType { get; set; }
        public string? RoomTypeId { get; set; }
        public double Price { get; set; }
        public bool IsRoomService { get; set; }
        public RoomService? RoomService { get; set; }
        public string? RoomNumber { get; set; }
        public string? CustomerID { get; set; }
        public Status CustomerStatus { get; set; }
        public int Nights { get; set; }
        public DatePeriod StayPeriod { get; set; }
        public double TotalPriceOfStay { get; set; }
        public bool Rate { get; set; }
    }
}