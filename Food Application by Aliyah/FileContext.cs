using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;

namespace Food_Application_Project
{
    public class FileContext
    {
        public string Deposit = @".\foodapp\deposits.txt";
        public string Food = @".\foodapp\foods.txt";
        public string Ordering = @".\foodapp\orderings.txt";
        public string User = @".\foodapp\users.txt";
        public string Wallet = @".\foodapp\wallets.txt";
        





        public static List<Deposit> deposits = new List<Deposit>();
        public static List<Food> foods = new List<Food>();
        public static List<Ordering> orderings = new List<Ordering>();
        public static List<User> users = new List<User>();
        public static List<Wallet> wallets = new List<Wallet>();
    }
}