using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Union_Voting_App.Models.Entities
{
    public class Contestant : Auditables
    {
        public string MatricNo { get; set; }
        public string PositionName { get; set; }
    }
}