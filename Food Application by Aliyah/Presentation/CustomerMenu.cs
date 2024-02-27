using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Manager.Implementation;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project
{
    public class CustomerMenu
    {
        IFoodManager foodManager = new FoodManager();
        IOrderingManager orderingManager = new OrderingManager();
        IDepositManager depositManager = new DepositManager();
        IWalletManager walletManager = new WalletManager();

        public string Customer(string email)
        {
            Console.WriteLine("Press 1. To Order\nPress2. To top up your wallet\nPress 3. To check wallet balance\nPress 4. To view all available foods\nPress 5. To log out");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Ordering();
                    Customer(email);
                    break;
                case 2:
                    Deposit(email);
                    Customer(email);
                    break;
                case 3:
                    CheckWalletBalance();
                    Customer(email);
                    break;
                case 4:
                    ViewAvailableFoods();
                    Customer(email);
                    break;
                case 5:
                    Menu menu = new Menu();
                    menu.MainMenu();
                    break;
                default:
                    System.Console.WriteLine("Enter the correct number in the above list :");
                    break;
            }
            return null;
        }
        public void Ordering()
        {
            try
            {
                Console.WriteLine("Enter the food name you want to purchase");
                string foodName = Console.ReadLine();
                string managerwallet = "0";
                System.Console.WriteLine("Enter your account number");
                string customerWallet = Console.ReadLine();
                Console.WriteLine("Enter the quantity of food");
                double quantity = double.Parse(Console.ReadLine());
                DateTime date = DateTime.Now;

                var fd = foodManager.Get(foodName);
                var foodPrice = fd.Price * quantity;

                var ordering = orderingManager.MakeOrder(foodName, quantity, customerWallet, managerwallet, foodPrice, date);
                if (ordering != null)
                {
                    Console.WriteLine("Payment Successful !!!!!!!");
                    Console.WriteLine($"Your Order RefrenceNumber is {GenerateRefNo}");
                }
                else
                {
                    Console.WriteLine("Payment not successful !!!");
                }
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.Source);
            }

        }
        public void Deposit(string email)
        {
            Console.WriteLine("Enter the amount you want to deposit");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your account number");
            string accountNumber = Console.ReadLine();
        
            var deposit = depositManager.DepositMoney(accountNumber, amount);
            if (deposit != null)
            {
                Console.WriteLine("Deposit Successful");
            }
            else
            {
                Console.WriteLine("No deposit available");
            }
        }
        public void CheckWalletBalance()
        {
            Console.WriteLine("Enter your accountNumber");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            var wallet = walletManager.GetWalletByEmail(email);
             if (wallet != null)
            {
                var checkWallet = walletManager.CheckWallet(accountNumber,email);
                Console.WriteLine($"Your available amount in your wallet is {checkWallet.Amount}");
            }
            else
            {
                Console.WriteLine("Wallet Doesn't Exist");
            }
        }
        public void ViewAvailableFoods()
        {
            var food = foodManager.GetAll();
            foreach (var foods in food)
            {
                System.Console.WriteLine($"{foods.FoodName} {foods.Price} {foods.FoodType}");
            }
        }
        public string GenerateAccountNumber()
        {
            Random random = new Random();
            string num = random.Next(1000, 9999).ToString();
            System.Console.WriteLine(num);
            return num;
        }
        public string GenerateRefNo()
        {
            Random random = new Random();
            string nums = random.Next(100, 999).ToString();
            return nums;
        }
    }
}