using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Union_Voting_App.Models.Entities
{
    public class DatePeriod
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }

        public DatePeriod(DateOnly start, DateOnly end)
        {
            Start = start;
            End = end;
        }

        public bool WithInRange(DateOnly value)
        {
            return (Start <= value) && (value <= End);
        }
    }
}