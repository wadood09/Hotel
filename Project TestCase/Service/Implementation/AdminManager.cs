using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class AdminManager : IManager<Admin>
    {
        IRepository<Admin> Repository = new AdminRepository();
        public bool IsExist(string email)
        {
            foreach (Admin admin in HotelContext.Admins)
            {
                if (admin.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login(string email, string password)
    {
        foreach (Admin admin in HotelContext.Admins)
        {
            if(admin.Email == email && admin.Password == password)
            {
                Admin.LoggedInAdminId = admin.Id;
                return true;
            }
        }
        return false;
    }

        public void Register(Admin admin)
        {
            if (IsExist(admin.Email))
            {
                Console.WriteLine($"Admin with email {admin.Email} already exists");
            }
            else
            {
                Repository.Add(admin);
                Console.WriteLine("Registration Successfull");
            }
        }
    }
}