using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Repositories.Implementation;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;
using My_Dapper_DTO_Project_Testcase.Services.Interface;

namespace My_Dapper_DTO_Project_Testcase.Services.Implementation
{
    public class UserService : IUserService
    {
        IRepository<User> repository = new UserRepository();
        IRepository<Admin> adminRepo = new AdminRepository();
        IRepository<Customer> customerRepo = new CustomerRepository();

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
            {
                Admin admin = new()
                {
                    UserEmail = user.Email
                };
                adminRepo.Add(admin);
            }
            else
            {
                Customer customer = new()
                {
                    UserEmail = user.Email
                };
                customerRepo.Add(customer);
            }
            
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

        public void Delete(User user)
        {
            repository.Remove(user);
        }

        public bool IsExist(string email, string role)
        {
            bool isExist = repository.GetAll().SingleOrDefault(user => user.Email == email && user.Role == role) is not null;
            return isExist;
        }

        public (bool, List<User>) Login(string email, string password)
        {
            List<User> user = repository.GetAll().Where(user => user.Email == email && user.Password == password).ToList();
            return(user.Any(), user);
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