using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.DTO
{
    public class AdminResponseModel : Auditables
    {
        public string UserEmail { get; set; } = default!;
    }

    public class AdminResquestModel
    {
        public string UserEmail { get; set; } = default!;
    }
}