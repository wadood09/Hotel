using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Enums;

namespace My_File_Project.Models.Entities
{
    public class Room : Auditables
    {
        public string? HotelId { get; set; }
        public string? RoomTypeId { get; set; }
        public string? Number { get; set; }
        public RoomStatus RoomStatus { get; set; } = RoomStatus.Vacant;
    }
}