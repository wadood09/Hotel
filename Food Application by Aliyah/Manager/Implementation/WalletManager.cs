using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;
using Microsoft.VisualBasic;

namespace Food_Application_Project.Manager.Implementation
{
    public class WalletManager : IWalletManager
    {
        IWalletRepository walletRepo = new WalletRepository();
        public Wallet AddWallet(Wallet wallet)
        {
            walletRepo.AddWallet(wallet);
            return wallet;
        }
        public Wallet CheckWallet(string accountNumber)
        {
            var exist = FileContext.wallets.SingleOrDefault(a => a.AccountNumber == accountNumber && a.Useremail == User.LoggedInUserEmail);
            return exist;
        }

        public Wallet GetWallet(string accountNumber)
        {
            var exist = walletRepo.Get(a => a.AccountNumber == accountNumber);
            return exist;
        }

        public List<Wallet> GetWallets()
        {
            return walletRepo.GetAll();
        }
        public void UpdateList()
        {
            walletRepo.ReadAllFromFile();
        }
    }
}