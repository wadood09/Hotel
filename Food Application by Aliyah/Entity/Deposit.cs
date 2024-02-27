using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Application_Project.Entity
{
    public class Deposit : Base
    {
        public string WalletAccountNumber{get;set;}
        public string RefNo{get;set;} = Guid.NewGuid().ToString();
        public double Amount{get;set;}

        public Deposit(string walletAccountNumber,double amount)
        {
            WalletAccountNumber = walletAccountNumber;
            Amount = amount;
        }
        public Deposit()
        {

        }

        public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{WalletAccountNumber}\t{RefNo}\t{Amount}";
        }

        public static Deposit ToDeposit(string str)
        {
            var depot = str.Split('\t');
            return new Deposit()
            {
                Id = int.Parse(depot[0]),
                CreatedAt = DateTime.Parse(depot[1]),
                WalletAccountNumber = depot[2],
                RefNo = depot[3],
                Amount = double.Parse(depot[4]),
            };
        }
    }
}