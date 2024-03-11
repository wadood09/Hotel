
using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IStaffService
    {
        void CreateStaff(string userId);
        Staff? Get(Func<Staff, bool> pred);
        List<Staff> GetSelected(Func<Staff, bool> pred);
        void Delete(Staff staff);
        void Update(Staff staff);
    }
}