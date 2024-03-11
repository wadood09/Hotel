using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Implementation;
using My_Dapper_Project_2.Repositories.Interface;
using My_Dapper_Project_2.Services.Interface;

namespace My_Dapper_Project_2.Services.Implementation
{
    public class WalletService : IWalletService
    {
        IRepository<Wallet> repository = new WalletRepository();
        public Wallet CreateWallet()
        {
            var wallet = new Wallet
            {
                WalletBalance = 0
            };
            repository.Add(wallet);
            return repository.GetAll().Last();
        }

        public void Delete(Wallet wallet)
        {
            repository.Remove(wallet);
        }

        public Wallet? Get(Func<Wallet, bool> pred)
        {
            return repository.GetAll().SingleOrDefault(pred);
        }

        public List<Wallet> GetSelected(Func<Wallet, bool> pred)
        {
            return repository.GetAll().Where(pred).ToList();
        }

        public void Update(Wallet wallet)
        {
            repository.Update(wallet);
        }
    }
}