using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        ICustomerRepository customerRepo = new CustomerRepository();
        public CustomerManager()
        {
            customerRepo.ReadAllFromFile();
        }
        public User Get(string email)
        {
            var userExist = customerRepo.Get(user => user.Email == email);
            if (userExist == null)
            {
                return null;
            }
            return userExist;
        }

        public List<User> GetAll()
        {
            return customerRepo.GetAll();
        }
    }
}