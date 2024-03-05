using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class CustomerResponseModel : Auditables
    {
        public string UserEmail { get; set; } = default!;
    }

    public class CustomerRequestModel
    {
        public string UserEmail { get; set; } = default!;
    }
}