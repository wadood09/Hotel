using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface IAdminService
    {
        void CreateAdmin(AdminResquestModel admin);
        AdminResponseModel? Get(Func<Admin, bool> pred);
        Admin? Get(Func<Admin, bool> pred, string serv);
        List<AdminResponseModel> GetSelected(Func<Admin, bool> pred);
        List<Admin> GetSelected(Func<Admin, bool> pred, string serv);
        bool IsDeleted(Admin admin);
        void Update(AdminResponseModel model);
    }
}