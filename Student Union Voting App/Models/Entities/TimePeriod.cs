using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Union_Voting_App.Models.Entities
{
    public class TimePeriod
    {
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }

        public TimePeriod(TimeOnly start, TimeOnly end)
        {
            Start = start;
            End = end;
        }

        public bool WithInRange(TimeOnly value)
        {
            return (Start <= value) && (value <= End);
        }
    }
}