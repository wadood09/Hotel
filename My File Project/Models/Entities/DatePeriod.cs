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
    }
}