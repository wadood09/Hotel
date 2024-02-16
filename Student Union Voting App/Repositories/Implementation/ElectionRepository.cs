using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Repositories.Interface;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class ElectionRepository : IRepository<Election>
    {
        public void Drop(Election election)
        {
            ContextDB.Elections.Add(election);

            using (StreamWriter writer = new(ContextDB.ElectionFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(election));
            }
        }

        public Election Get(Func<Election, bool> pred)
        {
            return ContextDB.Elections.SingleOrDefault(pred);
        }

        public List<Election> GetAll()
        {
            return ContextDB.Elections;
        }

        public List<Election> GetSelected(Func<Election, bool> pred)
        {
            return ContextDB.Elections.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] elections = File.ReadAllLines(ContextDB.ElectionFile);
            foreach (string election in elections)
            {
                ContextDB.Elections.Add(JsonSerializer.Deserialize<Election>(election));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.ElectionFile, false))
            {
                foreach (Election election in ContextDB.Elections)
                {
                    writer.WriteLine(JsonSerializer.Serialize(election));
                }
            }
        }
    }
}