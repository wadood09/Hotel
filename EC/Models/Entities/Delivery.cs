using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.Models.Entities
{
    public class Delivery : Auditables
    {
        public string UserEmail{get; set;}
        public string StaffNumber{get; set;}
        public string PlateNumber{get; set;}

    }
}