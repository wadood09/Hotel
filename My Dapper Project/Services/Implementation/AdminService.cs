
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Models.Enums;
using My_Dapper_Project.Repositories.Implementation;
using My_Dapper_Project.Repositories.Interface;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private static string _connectionString = default!;
        public AdminService(string connectionString)
        {
            _connectionString = connectionString;
        }
        IRepository<Admin> repository = new AdminRepository(_connectionString);
        IHotelService hotelService = new HotelService();
        IUserService userService = new UserService();
        public void CreateAdmin(Admin model)
        {
            Admin admin = new()
            {
                UserEmail = model.UserEmail
            };
            repository.Add(admin);
        }

        public Admin? Get(Func<Admin, bool> pred)
        {
            Admin? admin = repository.GetAll().SingleOrDefault(pred);
            if (admin is null) return null;
            Admin model = new()
            {
                UserEmail = admin.UserEmail,
                Id = admin.Id
            };
            return model;
        }
        public List<Admin> GetSelected(Func<Admin, bool> pred)
        {
            return repository.GetAll().Where(pred).Select(admin => new Admin()
            {
                UserEmail = admin.UserEmail,
                Id = admin.Id
            }).ToList();
        }

        public bool IsDeleted(Admin admin)
        {
            List<Hotel> hotels = hotelService.GetSelected(hotel => hotel.AdminId == admin.Id);
            bool isActive = hotels.Any(hotel => hotel.HotelStatus == Status.Active);
            if (isActive) return false;

            foreach (Hotel hotel in hotels)
            {
                bool isDeleted = hotelService.IsDeleted(hotel);
                if (!isDeleted) return false;
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