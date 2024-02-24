using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Dapper_Project.Models.Entities
{
    public class RoomService : Auditables
    {
        public string? HotelId {get; set;}
        public string? Name {get; set;}
        public double Price {get; set;}
    }
}