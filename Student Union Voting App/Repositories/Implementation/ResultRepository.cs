using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Repositories.Interface;
using Student_Union_Voting_App.Models.Entities;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class ResultRepository : IRepository<Result>
    {
        public void Drop(Result result)
        {
            ContextDB.Results.Add(result);

            using (StreamWriter writer = new(ContextDB.ResultFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(result));
            }
        }

        public Result Get(Func<Result, bool> pred)
        {
            return ContextDB.Results.SingleOrDefault(pred);
        }

        public List<Result> GetAll()
        {
            return ContextDB.Results;
        }

        public List<Result> GetSelected(Func<Result, bool> pred)
        {
            return ContextDB.Results.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] results = File.ReadAllLines(ContextDB.ResultFile);
            foreach (string result in results)
            {
                ContextDB.Results.Add(JsonSerializer.Deserialize<Result>(result));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.ResultFile, false))
            {
                foreach (Result result in ContextDB.Results)
                {
                    writer.WriteLine(JsonSerializer.Serialize(result));
                }
            }
        }
    }
}