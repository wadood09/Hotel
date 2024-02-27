using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Manager.Implementation
{
    public class DepositManager : IDepositManager
    {
        WalletManager walletManager = new WalletManager();
        IDepositRepository depositRepo = new DepositRepository();

        IWalletRepository walletRepo = new WalletRepository();
        public DepositManager()
        {
            depositRepo.ReadAllFromFile();
        }
        public Deposit DepositMoney(string walletAccountNumber,double amount)
        {
            var wallet = walletManager.GetWallet(walletAccountNumber);
            if (amount > 0)
            {
                wallet.Amount += amount;
            }
            Deposit deposit = new Deposit(wallet.AccountNumber , amount);
            depositRepo.DepositMoney(deposit);
            walletRepo.UpdateWalletBalance(wallet, amount);
            return deposit;
        }

        public Deposit Get(string refNo)
        {
            var exist = depositRepo.Get(deposit => deposit.RefNo == refNo);
            if (exist == null)
            {
                return null;
            }
            return exist;
        }

        public List<Deposit> GetAll()
        {
            return depositRepo.GetAll();
        }
    }
}

        