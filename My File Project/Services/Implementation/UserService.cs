using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class UserService : IUserService
    {
        IRepository<User> repository = new UserRepository();
        IAdminService adminService = new AdminService();
        ICustomerService customerService = new CustomerService();
        public User? CreateUser(string firstName, string lastName, DateTime dob, string email, string password, string role)
        {
            if (IsExist(email, role)) return null;

            User user = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Dob = dob,
                Email = email,
                Password = password,
                Role = role
            };

            if (role == "ADMIN")
                adminService.CreateAdmin(user.Id);
            else
                customerService.CreateCustomer(user.Id);
            repository.Add(user);
            return user;
        }

        public User? Get(Func<User, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<User> GetSelected(Func<User, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public bool IsExist(string email, string role)
        {
            bool isExist = repository.GetAll().SingleOrDefault(user => user.Email == email && user.Role == role) is not null;
            return isExist;
        }

        public (bool, User?) IsLogin(string email, string password)
        {
            User? user = repository.GetAll().SingleOrDefault(user => user.Email == email && user.Password == password);
            if(user is not null) return (true, user);
            else return(false, null);
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }
    }
}