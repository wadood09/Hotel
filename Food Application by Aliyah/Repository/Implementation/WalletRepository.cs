using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Repository.Implementation
{
    public class WalletRepository : IWalletRepository
    {
        FileContext context = new FileContext();

        public Wallet AddWallet(Wallet wallet)
        {
            FileContext.wallets.Add(wallet);
            using (var str = new StreamWriter(context.Wallet, true))
            {
                str.WriteLine(wallet.ToString());
            }
            return wallet;
        }

        public Wallet Get(Func<Wallet, bool> pred)
        {
            return FileContext.wallets.SingleOrDefault(pred);
        }

        public List<Wallet> GetAll()
        {
            return FileContext.wallets;
        }


        public void ReadAllFromFile()
        {
            try
            {
                var wallet = File.ReadAllLines(context.Wallet);
                foreach (var item in wallet)
                {
                    FileContext.wallets.Add(Wallet.ToWallet(item));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;

        }


        public void RefreshFile()
        {
            using (var str = new StreamWriter(context.Wallet, false))
            {
                foreach (var item in FileContext.wallets)
                {
                    str.WriteLine(item.ToString());
                }
            }

        }
    }
}