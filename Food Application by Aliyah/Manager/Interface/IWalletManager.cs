using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;

namespace Food_Application_Project.Manager.Interface
{
    public interface IWalletManager
    {
        Wallet AddWallet(Wallet wallet);
        public Wallet CheckWallet(string accountNumber,string email);
        public Wallet GetWallet(string accountNumber);
        public List<Wallet> GetWallets();
        public Wallet GetWalletByEmail(string email);
    }
}