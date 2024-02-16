using System.Text.Json;
using Student_Union_Voting_App.Context;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Repositories.Interface;

namespace Student_Union_Voting_App.Repositories.Implementation
{
    public class UserRepository : IRepository<User>
    {
        public void Drop(User user)
        {
            ContextDB.Users.Add(user);

            using (StreamWriter writer = new(ContextDB.UserFile))
            {
                writer.WriteLine(JsonSerializer.Serialize(user));
            }
        }

        public User Get(Func<User, bool> pred)
        {
            return ContextDB.Users.SingleOrDefault(pred);
        }

        public List<User> GetAll()
        {
            return ContextDB.Users;
        }

        public List<User> GetSelected(Func<User, bool> pred)
        {
            return ContextDB.Users.Where(pred).ToList();
        }

        public void ReadAllFromFile()
        {
            string[] users = File.ReadAllLines(ContextDB.UserFile);
            foreach (string user in users)
            {
                ContextDB.Users.Add(JsonSerializer.Deserialize<User>(user));
            }
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(ContextDB.UserFile, false))
            {
                foreach (User user in ContextDB.Users)
                {
                    writer.WriteLine(JsonSerializer.Serialize(user));
                }
            }
        }
    }
}