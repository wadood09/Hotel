
using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IOrganizationService
    {
        void CreateOrganization(string name);
        Organization? Get(Func<Organization, bool> pred);
        List<Organization> GetSelected(Func<Organization, bool> pred);
        bool IsDeleted(Organization organization);
        void Update(Organization organization);
    }
}