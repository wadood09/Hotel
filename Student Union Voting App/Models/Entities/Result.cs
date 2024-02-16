namespace Student_Union_Voting_App.Models.Entities
{
    public class Result : Auditables
    {
        public string RefNumber { get; set; }
        public Dictionary<string, Dictionary<string, int>> Outcome { get; set; }
    }
}