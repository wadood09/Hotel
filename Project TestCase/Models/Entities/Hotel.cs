using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Enums;

namespace My_File_Project.Models.Entities
{
    public class Hotel : Auditables
    {
        public string? Name {get; set;}
        public bool HasRoomService {get; set;}
        public string? AdminId {get; set;}
        public Status HotelStatus {get; set;} = Status.Inactive;
        public double Ratings {get; set;}
        public double EarlyCheckOutFee {get; set;}
    }
}