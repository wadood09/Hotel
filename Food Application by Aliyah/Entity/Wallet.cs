using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Application_Project.Entity
{
    public class Wallet : Base
    {
        public string AccountNumber{get;set;}
        public double Amount{get;set;}
        public string Useremail{get;set;}
        


        public Wallet(string useremail, string phonenumber)
        {
            AccountNumber = $"MYK{phonenumber.Substring(1)}";

            Useremail = useremail;
            CreatedAt = DateTime.Now;
            Amount = 0;
        }

        public Wallet()
        {

        }


        public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{AccountNumber}\t{Amount}\t{Useremail}";
        }

        public static Wallet ToWallet(string str)
        {
            var wallet = str.Split('\t');
            return new Wallet()
            {
                Id = int.Parse(wallet[0]),
                CreatedAt = DateTime.Parse(wallet[1]),
                AccountNumber = wallet[2],
                Amount = double.Parse(wallet[3]),
                Useremail = wallet[4],
            };
        }
    }
}