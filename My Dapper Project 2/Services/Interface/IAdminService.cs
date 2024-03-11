using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IAdminService
    {
        void CreateAdmin(string userId);
        Admin? Get(Func<Admin, bool> pred);
        List<Admin> GetSelected(Func<Admin, bool> pred);
        bool IsDeleted(Admin admin);
        void Update(Admin admin);
    }
}