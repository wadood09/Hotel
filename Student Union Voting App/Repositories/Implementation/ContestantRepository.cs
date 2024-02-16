using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Repositories.Interface;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class ContestantRepository : IRepository<Contestant>
    {
        public void Drop(Contestant contestant)
        {
            ContextDB.Contestants.Add(contestant);

            using (StreamWriter writer = new(ContextDB.ContestantFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(contestant));
            }
        }

        public Contestant Get(Func<Contestant, bool> pred)
        {
            return ContextDB.Contestants.SingleOrDefault(pred);
        }

        public List<Contestant> GetAll()
        {
            return ContextDB.Contestants;
        }

        public List<Contestant> GetSelected(Func<Contestant, bool> pred)
        {
            return ContextDB.Contestants.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] contestants = File.ReadAllLines(ContextDB.ContestantFile);
            foreach (string contestant in contestants)
            {
                ContextDB.Contestants.Add(JsonSerializer.Deserialize<Contestant>(contestant));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.ContestantFile, false))
            {
                foreach (Contestant contestant in ContextDB.Contestants)
                {
                    writer.WriteLine(JsonSerializer.Serialize(contestant));
                }
            }
        }
    }
}