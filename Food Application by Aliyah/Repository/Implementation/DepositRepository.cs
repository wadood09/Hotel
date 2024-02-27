using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Repository.Implementation
{
    public class DepositRepository : IDepositRepository
    {
        FileContext context = new FileContext();

        public Deposit DepositMoney(Deposit deposit)
        {
            FileContext.deposits.Add(deposit);
            return deposit;
        }

        
        public List<Deposit> GetAll()
        {
            return FileContext.deposits;

        }

        public void ReadAllFromFile()
        {
            try
            {
                var fileExist = File.Exists(context.Deposit);
                if(fileExist)
                {
                    var deposit = File.ReadAllLines(context.Deposit);
                    foreach (var item in deposit)
                    {
                        FileContext.deposits.Add(Deposit.ToDeposit(item));
                    }  
                }
                else
                {
                    File.Create(context.Deposit);
                }  
            }
            catch(System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;
            
        }

        public void RefreshFile()
        {
            using(var str = new StreamWriter(context.Deposit, false))
            {
                foreach (var item in FileContext.deposits)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }

        public Deposit Get(Func<Deposit, bool> pred)
        {
            return FileContext.deposits.SingleOrDefault(pred);
            
        }
    }
}