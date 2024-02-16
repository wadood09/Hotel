namespace Student_Union_Voting_App.Models.Entities
{
    public class Voting : Auditables
    {
        public string MatricNo { get; set; }
        public string RefNumber { get; set; }
        public Dictionary<Position, Contestant> VotingList { get; set; }
    }
}