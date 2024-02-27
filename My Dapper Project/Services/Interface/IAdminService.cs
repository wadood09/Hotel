using My_Dapper_Project.Models.Entities;

namespace My_Dapper_Project.Services.Interface
{
    public interface IAdminService
    {
        void CreateAdmin(string userId);
        Admin? Get(Func<Admin, bool> pred);
        List<Admin> GetSelected(Func<Admin, bool> pred);
        bool IsDeleted(Admin admin);
        void UpdateFile();
        void UpdateList();
    }
}