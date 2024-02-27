using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Dapper_Project.Models.Entities
{
    public class RoomService : Auditables
    {
        public string HotelId {get; set;} = default!;
        public string Name {get; set;} = default!;
        public double Price {get; set;}
    }
}