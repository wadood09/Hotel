using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class RoomResponseModel : Auditables
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public string Number { get; set; } = default!;
        public RoomStatus RoomStatus { get; set; }
    }

    public class RoomRequestModel
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public string Number { get; set; } = default!;
    }
}