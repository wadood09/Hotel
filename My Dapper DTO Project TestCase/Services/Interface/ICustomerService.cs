using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerRequestModel customer);
        CustomerResponseModel? Get(Func<Customer, bool> pred);
        Customer? Get(Func<Customer, bool> pred, string serv);
        List<CustomerResponseModel> GetSelected(Func<Customer, bool> pred);
        List<Customer> GetSelected(Func<Customer, bool> pred, string serv);
        bool IsDeleted(Customer customer);
        void Update();
    }
}