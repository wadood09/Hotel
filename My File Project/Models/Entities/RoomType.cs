using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Enums;

namespace My_File_Project.Models.Entities
{
    public class RoomType
    {
        public string? HotelId {get; set;}
        public string? Name {get; set;}
        public int AmountOfRooms {get; set;}
        public double Price {get; set;}
        public Status Status {get; set;} = Status.Inactive;
    }
}