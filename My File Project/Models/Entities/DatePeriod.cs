namespace My_File_Project.Entities
{
    public struct DatePeriod
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

        public bool WithInRange(DatePeriod period)
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
            Start = DateTime.Now.AddDays(days);
        }

        public TimeSpan GetDifference()
        {
            TimeSpan difference = End - Start;
            return difference;
        }
    }
}