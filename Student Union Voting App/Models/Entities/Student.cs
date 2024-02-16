using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Union_Voting_App.Models.Entities
{
    public class Student : Auditables
    {
        public string UserEmail { get; set;}
        public string MatricNo { get; set;}
        public int GP { get; set;}
        public int Level { get; set;}
    }
}