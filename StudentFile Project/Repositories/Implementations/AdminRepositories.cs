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
    public class AdminRepositories : IAdminRepositories
    {
        FileContext file = new FileContext();
        public void Drop(Admin admin)
        {
            FileContext.AdminDb.Add(admin);
            using (var str = new StreamWriter(file.AdminFile, true))
            {
                var b = JsonSerializer.Serialize(admin);
                str.WriteLine(b);
            }

        }

        public List<Admin> GetAllAdmin()
        {
            var get = FileContext.AdminDb;
            return get;
        }

        public Admin GetById(string id)
        {
            var get = FileContext.AdminDb;
            foreach (var item in get)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void ReadAllFromFile()
        {
            var read = File.ReadAllLines(file.AdminFile);
            foreach (var item in read)
            {
                var b = JsonSerializer.Deserialize<Admin>(item)!;
                FileContext.AdminDb.Add(b);
            }
        }

        public void RefreshFile()
        {
            using (var refs = new StreamWriter(file.AdminFile, false))
            {
                foreach (var item in FileContext.AdminDb)
                {
                    var b = JsonSerializer.Serialize(item);
                    refs.WriteLine(b);

                }
            }
        }

        public void Remove(string id)
        {
            var delete = GetById(id);
            FileContext.AdminDb.Remove(delete);
            RefreshFile();
        }
    }
}