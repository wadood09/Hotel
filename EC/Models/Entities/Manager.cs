using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.Models.Entities
{
    public class Manager : Auditables
    {
        public string UserEmail{get; set;}
        public string StaffNumber{get; set;}

        public override string ToString()
        {
            return $"{Id}\t{UserEmail}\t{StaffNumber}\t{IsDeleted}";
        }

        public Manager ToManager(string str)
        {
            var model = str.Split('\t');
            return new Manager()
            {
                Id = model[0],
                UserEmail = model[1],
                StaffNumber = model[2],
                IsDeleted = bool.Parse(model[3])
            };
        }
    }
}