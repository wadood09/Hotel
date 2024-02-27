namespace My_Dapper_DTO_Project_Testcase.Entities
{
    public struct DatePeriod : IComparable<DatePeriod>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DatePeriod(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public bool WithInRange(DateTime value)
        {
            bool IsWithinRange = (Start <= value) && (value <= End);
            return IsWithinRange;
        }

        public bool Intersects(DatePeriod period)
        {
            bool IsWithinRange = (Start <= period.Start) && (period.Start <= End) || (Start <= period.End) && (period.End <= End);
            return IsWithinRange;
        }

        public void IncreaseStartTime(int days)
        {
            Start = Start.AddDays(days);
        }

        public void IncreaseEndTime(int days)
        {
            End = End.AddDays(days);
        }

        public void ChangeStartTime(int days)
        {
            days = Math.Abs(days);
            Start = DateTime.Today.AddDays(days);
        }

        public TimeSpan GetDifference()
        {
            TimeSpan difference = End - Start;
            return difference;
        }

        public int CompareTo(DatePeriod other)
        {
            if(Start > other.Start) return -1;
            else if(other.Start > Start) return 1;
            else return 0;
        }
    }
}