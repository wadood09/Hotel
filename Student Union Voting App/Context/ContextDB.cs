using Student_Union_Voting_App.Models.Entities;

namespace Student_Union_Voting_App.Context
{
    public class ContextDB
    {
        public static List<Contestant> Contestants = new();
        public static List<Election> Elections = new();
        public static List<ElectoralChairman> ElectoralChairmen = new();
        public static List<Position> Positions = new();
        public static List<Result> Results = new();
        public static List<Student> Students = new();
        public static List<User> Users = new();
        public static List<Voting> Votings = new();


        public static string ContestantFile = "Files\\Contestants.txt";
        public static string ElectionFile = "Files\\Elections.txt";
        public static string ElectoralChairmanFile = "Files\\ElectoralChairmen.txt";
        public static string PositionFile = "Files\\Positions.txt";
        public static string ResultFile = "Files\\Results.txt";
        public static string StudentFile = "Files\\Students.txt";
        public static string UserFile = "Files\\Users.txt";
        public static string VotingFile = "Files\\Votings.txt";
    }
}