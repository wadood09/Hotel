using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Repositories.Interface;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class PositionRepository : IRepository<Position>
    {
        public void Drop(Position position)
        {
            ContextDB.Positions.Add(position);

            using (StreamWriter writer = new(ContextDB.PositionFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(position));
            }
        }

        public Position Get(Func<Position, bool> pred)
        {
            return ContextDB.Positions.SingleOrDefault(pred);
        }

        public List<Position> GetAll()
        {
            return ContextDB.Positions;
        }

        public List<Position> GetSelected(Func<Position, bool> pred)
        {
            return ContextDB.Positions.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] positions = File.ReadAllLines(ContextDB.PositionFile);
            foreach (string position in positions)
            {
                ContextDB.Positions.Add(JsonSerializer.Deserialize<Position>(position));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.PositionFile, false))
            {
                foreach (Position position in ContextDB.Positions)
                {
                    writer.WriteLine(JsonSerializer.Serialize(position));
                }
            }
        }
    }
}