using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        IRepository<Customer> repository = new CustomerRepository();
        public void CreateCustomer(string userId)
        {
            Customer customer = new()
            {
                UserId = userId
            };
            repository.Add(customer);
        }

        public Customer? Get(Func<Customer, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<Customer> GetSelected(Func<Customer, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }
    }
}