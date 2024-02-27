using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;

namespace Food_Application_Project.Repository.Interface
{
    public interface IWalletRepository
    {

        public Wallet Get(Func<Wallet, bool> pred);
        public List<Wallet> GetAll();
        public Wallet AddWallet(Wallet wallet);
        void ReadAllFromFile();
        void RefreshFile();
    }
}