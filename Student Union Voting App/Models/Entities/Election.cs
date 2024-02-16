using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Union_Voting_App.Models.Entities
{
    public class Election : Auditables
    {
        public string Name { get; set; }
        public DatePeriod VotingDatePeriod { get; set; }
        public TimePeriod VotingTimePeriod { get; set; }
        public List<int> PositionId { get; set; }
    }
}