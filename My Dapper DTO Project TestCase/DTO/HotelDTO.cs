using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class HotelResponseModel : Auditables
    {
        public string Name {get; set;} = default!;
        public bool HasRoomService {get; set;}
        public int AdminId {get; set;}
        public Status HotelStatus {get; set;}
        public double Ratings {get; set;}
    }

    public class HotelRequestModel
    {
        public string Name {get; set;} = default!;
        public bool HasRoomService {get; set;}
        public List<string> RoomTypes {get; set;} = default!;
        public List<double> RoomPrices {get; set;} = default!;
        public List<int> RoomAmount {get; set;} = default!;
        public List<List<string>> RoomNumbers {get; set;} = default!;
        public List<string> RoomServices {get; set;} = default!;
        public List<double> ServicePrices {get; set;} = default!;
    }
}