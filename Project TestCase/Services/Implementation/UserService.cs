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
        IRepository<Admin> adminRepo = new AdminRepository();
        IRepository<Customer> customerRepo = new CustomerRepository();

        public User? CreateUser(string firstName, string lastName, DateTime dob, string email, string password, string role)
        {
            if (IsExist(email, role)) return null;
            if(!AreTheSame(email, firstName, lastName, dob)) return null;

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
            bool isExist = repository.GetAll().Any(user => user.Email == email && user.Role == role);
            return isExist;
        }

        public bool AreTheSame(string email, string firstName, string lastName, DateTime dob)
        {
            User? user = repository.GetAll().SingleOrDefault(user => user.Email == email);
            if(user is null) return true;
            bool areTheSame = string.Equals(user.FirstName, firstName, StringComparison.OrdinalIgnoreCase) && string.Equals(user.LastName, lastName, StringComparison.OrdinalIgnoreCase) && user.Dob == dob;
            return areTheSame;
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