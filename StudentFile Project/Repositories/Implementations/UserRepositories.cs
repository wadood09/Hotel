using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using StudentFile_Project.Context;
using StudentFile_Project.Model.Entities;
using StudentFile_Project.Repositories.Interfaces;

namespace StudentFile_Project.Repositories.Implementations
{
    public class UserRepositories : IUserRepositories
    {
        FileContext file = new FileContext();
        public void Drop(User user)
        {
            FileContext.UserDB.Add(user);
            using(var intoFile = new StreamWriter(file.UserFile,true))
            {
              var ser = JsonSerializer.Serialize(user);
              intoFile.WriteLine(ser);
            }
        }

        public List<User> GetAll()
        {
            var getAll = FileContext.UserDB;
            return getAll;
        }

        public User GetbyEmail(string email)
        {
            foreach (var item in FileContext.UserDB)
            {
                if(item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }

        public void ReadAllFromFile()
        {
            var get = File.ReadAllLines(file.UserFile);
            foreach (var item in get)
            {
               var output = JsonSerializer.Deserialize<User>(item)!;
               FileContext.UserDB.Add(output); 
            }
        }

        public void RefreshFile()
        {
              using (var refs = new StreamWriter(file.UserFile, false))
            {
                foreach (var item in FileContext.UserDB)
                {
                    var b = JsonSerializer.Serialize(item);
                    refs.WriteLine(b);

                }
            }
        }

        public void Remove(string email)
        {
             var delete = GetbyEmail(email);
            FileContext.UserDB.Remove(delete);
            RefreshFile();
        }
    }
}