using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Union_Voting_App.Models.Entities
{
    public class ElectoralChairman : Auditables
    {
        public int ElectoralChairmanId { get; set; }
        public string MatricNo { get; set; }
        public string ElectionName { get; set; }
    }
}