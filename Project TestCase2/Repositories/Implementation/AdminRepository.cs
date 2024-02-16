using System.Text.Json;
using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class AdminRepository : IRepository<Admin>
    {
        public void Add(Admin admin)
        {
            HotelContext.Admins.Add(admin);
            
            // using (StreamWriter writer = new(HotelContext.AdminFile))
            // {
            //     writer.WriteLine(JsonSerializer.Serialize(admin));
            // }
        }

        public List<Admin> GetAll()
        {
            return HotelContext.Admins;
        }

        public Admin GetById(int id)
        {
            return HotelContext.Admins.FirstOrDefault(admin => admin.Id == id);
        }

        public void Remove(Admin admin)
        {
            HotelContext.Admins.Remove(admin);
        }
    }
}