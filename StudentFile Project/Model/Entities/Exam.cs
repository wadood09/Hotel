using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFile_Project.Model.Entities
{
    public class Exam : BaseEntities
    {
        public string Type{get;set;} = default!;
        public double Percentage{get;set;}
        public string Grade{get;set;} = default!;
        public string StudentId{get;set;} = default!;
        public double Score{get;set;}

      
    }
    
    
}