using System.Text.Json;
using My_File_Project.Context;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class AdminRepository : IRepository<Admin>
    {
        public void Add(Admin admin)
        {
            HotelContext.Admins.Add(admin);

            using (StreamWriter writer = new(HotelContext.AdminFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(admin));
            }
        }

        public Admin? Get(Func<Admin, bool> pred)
        {
            Admin? admin = HotelContext.Admins.SingleOrDefault(pred);
            return admin;
        }

        public List<Admin> GetAll()
        {
            return HotelContext.Admins;
        }

        public List<Admin> GetSelected(Func<Admin, bool> pred)
        {
            return HotelContext.Admins.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.AdminFile, false))
            {
                foreach (Admin admin in HotelContext.Admins)
                {
                    writer.WriteLine(JsonSerializer.Serialize(admin));
                }
            }
        }

        public void RefreshList()
        {
            string[] admins = File.ReadAllLines(HotelContext.AdminFile);
            foreach (string admin in admins)
            {
                HotelContext.Admins.Add(JsonSerializer.Deserialize<Admin>(admin)!);
            }
        }
    }
}