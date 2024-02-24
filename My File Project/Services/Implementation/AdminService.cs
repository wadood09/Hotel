using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;
using My_File_Project.Models.Enums;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class AdminService : IAdminService
    {
        IRepository<Admin> repository = new AdminRepository();
        IHotelService hotelService = new HotelService();
        IUserService userService = new UserService();
        public void CreateAdmin(string userEmail)
        {
            Admin admin = new()
            {
                UserEmail = userEmail
            };
            repository.Add(admin);
        }

        public Admin? Get(Func<Admin, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<Admin> GetSelected(Func<Admin, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public bool IsDeleted(Admin admin)
        {
            List<Hotel> hotels = hotelService.GetSelected(hotel => hotel.AdminId == admin.Id);
            bool isActive = hotels.Any(hotel => hotel.HotelStatus == Status.Active);
            if(isActive) return false;
            
            foreach (Hotel hotel in hotels)
            {
                bool isDeleted = hotelService.IsDeleted(hotel);
                if(!isDeleted) return false;
            }

            User user = userService.Get(user => user.Email == admin.UserEmail && user.Role == "ADMIN")!;
            userService.Delete(user);
            repository.Remove(admin);
            return true;
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }

        public void UpdateList()
        {
            repository.RefreshList();
        }
    }
}