
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Implementation;
using My_Dapper_Project.Repositories.Interface;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Services.Implementation
{
    public class UserService : IUserService
    {
        IRepository<User> repository = new UserRepository();
        IRepository<Admin> adminRepo = new AdminRepository();
        IRepository<Customer> customerRepo = new CustomerRepository();

        public User? CreateUser(string firstName, string lastName, DateTime dob, string email, string password, string role)
        {
            if (IsExist(email, role)) return null;

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Dob = dob,
                Email = email,
                Password = password,
                Role = role
            };

            repository.Add(user);
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
            return user;
        }


        public User? Get(Func<User, bool> pred)
        {
            return repository.GetAll().SingleOrDefault(pred);
        }

        public List<User> GetSelected(Func<User, bool> pred)
        {
            return repository.GetAll().Where(pred).ToList();
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

        public User? Login(string email, string password)
        {
            return Get(user => user.Email == email && user.Password == password);
        }

        public void Update(User user)
        {
            repository.Update(user);
        }
    }
}