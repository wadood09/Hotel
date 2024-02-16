using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        IRepository<Customer> repository = new CustomerRepository();
        public void CreateCustomer(string userEmail)
        {
            Customer customer = new()
            {
                UserEmail = userEmail
            };
            repository.Add(customer);
        }

        public Customer? Get(Func<Customer, bool> pred)
        {
            return repository.Get(pred);
        }
    }
}