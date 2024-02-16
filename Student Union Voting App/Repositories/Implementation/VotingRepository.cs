using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Repositories.Interface;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class VotingRepository : IRepository<Voting>
    {
        public void Drop(Voting voting)
        {
            ContextDB.Votings.Add(voting);

            using (StreamWriter writer = new(ContextDB.VotingFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(voting));
            }
        }

        public Voting Get(Func<Voting, bool> pred)
        {
            return ContextDB.Votings.SingleOrDefault(pred);
        }

        public List<Voting> GetAll()
        {
            return ContextDB.Votings;
        }

        public List<Voting> GetSelected(Func<Voting, bool> pred)
        {
            return ContextDB.Votings.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] votings = File.ReadAllLines(ContextDB.VotingFile);
            foreach (string voting in votings)
            {
                ContextDB.Votings.Add(JsonSerializer.Deserialize<Voting>(voting));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.VotingFile, false))
            {
                foreach (Voting voting in ContextDB.Votings)
                {
                    writer.WriteLine(JsonSerializer.Serialize(voting));
                }
            }
        }
    }
}