using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface ICustomerService
    {
        void CreateCustomer(string userId);
        Customer? Get(Func<Customer, bool> pred);
        List<Customer> GetSelected(Func<Customer, bool> pred);
        bool IsDeleted(Customer customer);
        void Update(Customer customer);
    }
}