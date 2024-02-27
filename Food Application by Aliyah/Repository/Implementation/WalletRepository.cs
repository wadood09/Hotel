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
        public WalletRepository()
        {
            ReadAllFromFile();
        }

        FileContext context = new FileContext();
        
        public Wallet AddWallet (Wallet wallet)
        {
            FileContext.wallets.Add(wallet);
            using(var str = new StreamWriter(context.Wallet, true))
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

        public Wallet GetByEmail(string userEmail)
        {
            var wallet = FileContext.wallets.SingleOrDefault(a => a.Useremail == userEmail);
            return wallet;
        }

        public void ReadAllFromFile()
        {
            try
            {
                var fileExist = File.Exists(context.Wallet);
                if(fileExist)
                {
                    var wallet = File.ReadAllLines(context.Wallet);
                    foreach (var item in wallet)
                    {
                        FileContext.wallets.Add(Wallet.ToWallet(item));
                    }  
                }
                else
                {
                    File.Create(context.Wallet);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;
             
        }

        public Wallet UpdateWalletBalance(Wallet wallet, double amount)
        {
            var myWallet = Get(a => a.AccountNumber == wallet.AccountNumber);
            myWallet.Amount = amount;
            RefreshFile();
            return wallet;
        }

        public void RefreshFile()
        {
            File.WriteAllText(context.Wallet, string.Empty);
            foreach (var item in FileContext.wallets)
            {
                using(var str = new StreamWriter(context.Wallet, true))
                {
                    str.WriteLine(item.ToString());
                }
            }
        }
    }
}