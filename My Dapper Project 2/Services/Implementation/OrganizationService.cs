using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Implementation;
using My_Dapper_Project_2.Repositories.Interface;
using My_Dapper_Project_2.Services.Interface;

namespace My_Dapper_Project_2.Services.Implementation
{
    public class OrganizationService : IOrganizationService
    {
        IRepository<Organization> repository = new OrganizationRepository();
        IWalletService walletService = new WalletService();
        public void CreateOrganization(string name)
        {
            Wallet wallet = walletService.CreateWallet();
            var organization = new Organization
            {
                Name = name,
                WalletId = wallet.Id
            };
            repository.Add(organization);
        }

        public Organization? Get(Func<Organization, bool> pred)
        {
            throw new NotImplementedException();
        }

        public List<Organization> GetSelected(Func<Organization, bool> pred)
        {
            throw new NotImplementedException();
        }

        public bool IsDeleted(Organization organization)
        {
            throw new NotImplementedException();
        }

        public void Update(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}