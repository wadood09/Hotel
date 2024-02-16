namespace Student_Union_Voting_App.Models.Entities
{
    public class Position : Auditables
    {
        public string Name { get; set; }
        public string ElectionName { get; set; }
        public int MinimumGP { get; set; }
        public int MinimumLevel { get; set; }
        public double TicketPrice { get; set; }
        public List<int> ContestantsId { get; set; }
    }
}