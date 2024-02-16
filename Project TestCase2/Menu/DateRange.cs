using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_TestCase2.DateRange
{
    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public bool WithInRange(DateTime value)
        {
            return (Start <= value) && (value <= End);
        }
    }
}