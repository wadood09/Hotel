
using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IWalletService
    {
        Wallet CreateWallet();
        Wallet? Get(Func<Wallet, bool> pred);
        List<Wallet> GetSelected(Func<Wallet, bool> pred);
        void Delete(Wallet wallet);
        void Update(Wallet wallet);
    }
}