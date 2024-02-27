using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;

namespace Food_Application_Project
{
    public class FileContext
    {
        public string Deposit = "foodApp\\deposits.txt";
        public string Food = "foodApp\\foods.txt";
        public string Ordering = "foodApp\\orderings.txt";
        public string User = "foodApp\\users.txt";
        public string Wallet = "foodApp\\wallets.txt";
        





        public static List<Deposit> deposits = new List<Deposit>();
        public static List<Food> foods = new List<Food>();
        public static List<Ordering> orderings = new List<Ordering>();
        public static List<User> users = new List<User>();
        public static List<Wallet> wallets = new List<Wallet>();
    }
}