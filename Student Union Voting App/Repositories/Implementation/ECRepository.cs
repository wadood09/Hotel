using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Repositories.Interface;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class ECRepository : IRepository<ElectoralChairman>
    {
        public void Drop(ElectoralChairman electoralChairman)
        {
            ContextDB.ElectoralChairmen.Add(electoralChairman);

            using (StreamWriter writer = new(ContextDB.ElectoralChairmanFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(electoralChairman));
            }
        }

        public ElectoralChairman Get(Func<ElectoralChairman, bool> pred)
        {
            return ContextDB.ElectoralChairmen.SingleOrDefault(pred);
        }

        public List<ElectoralChairman> GetAll()
        {
            return ContextDB.ElectoralChairmen;
        }

        public List<ElectoralChairman> GetSelected(Func<ElectoralChairman, bool> pred)
        {
            return ContextDB.ElectoralChairmen.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] electoralChairmen = File.ReadAllLines(ContextDB.ElectoralChairmanFile);
            foreach (string electoralChairman in electoralChairmen)
            {
                ContextDB.ElectoralChairmen.Add(JsonSerializer.Deserialize<ElectoralChairman>(electoralChairman));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.ElectoralChairmanFile, false))
            {
                foreach (ElectoralChairman electoralChairman in ContextDB.ElectoralChairmen)
                {
                    writer.WriteLine(JsonSerializer.Serialize(electoralChairman));
                }
            }
        }
    }
}