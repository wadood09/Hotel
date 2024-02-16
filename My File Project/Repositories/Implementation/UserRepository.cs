using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using My_File_Project.Context;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User user)
        {
            HotelContext.Users.Add(user);

            using (StreamWriter writer = new(HotelContext.UserFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(user));
            }
        }

        public User? Get(Func<User, bool> pred)
        {
            User? user = HotelContext.Users.SingleOrDefault(pred);
            return user;
        }

        public List<User> GetAll()
        {
            return HotelContext.Users;
        }

        public List<User> GetSelected(Func<User, bool> pred)
        {
            return HotelContext.Users.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.UserFile, false))
            {
                foreach (User user in HotelContext.Users)
                {
                    writer.WriteLine(JsonSerializer.Serialize(user));
                }
            }
        }

        public void RefreshList()
        {
            string[] users = File.ReadAllLines(HotelContext.UserFile);
            foreach (string user in users)
            {
                HotelContext.Users.Add(JsonSerializer.Deserialize<User>(user)!);
            }
        }
    }
}