using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerRequestModel customer);
        CustomerResponseModel? Get(Func<Customer, bool> pred);
        List<CustomerResponseModel> GetSelected(Func<Customer, bool> pred);
        bool IsDeleted(Customer customer);
        void Update();
    }
}