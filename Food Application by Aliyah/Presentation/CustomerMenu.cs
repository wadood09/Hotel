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
                var food = foodManager.GetAll();
                if (!food.Any())
                {
                    Console.WriteLine("No available foods at the moment!!!\nTry again later");
                    return;
                }

                ViewAvailableFoods();
                Console.WriteLine("Choose the food you want to purchase (i.e enter 1,2,3,...): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > food.Count)
                {
                    Console.WriteLine("Food Chosen does not exists!!!");
                    return;
                }

                System.Console.WriteLine("Enter your account number");
                string customerWallet = Console.ReadLine();

                Console.WriteLine("Enter the quantity of food");
                int quantity = int.Parse(Console.ReadLine());

                DateTime date = DateTime.Now;

                var foodPrice = food[--choice].Price * quantity;
                string refNo = GenerateRefNo();

                var ordering = orderingManager.MakeOrder(choice, quantity, customerWallet, refNo, foodPrice, date);
                if (ordering != null)
                {
                    Console.WriteLine("Payment Successful !!!!!!!");
                    Console.WriteLine($"Your Order RefrenceNumber is {refNo}");
                }
                else
                {
                    Console.WriteLine("Payment not successful!!!");
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
                Console.WriteLine("Incorrect Account Number!!!");
            }
        }
        public void CheckWalletBalance()
        {
            Console.WriteLine("Enter your accountNumber");
            string accountNumber = Console.ReadLine();
            var wallet = walletManager.GetWallet(accountNumber);
            if (wallet != null)
            {
                var checkWallet = walletManager.CheckWallet(accountNumber);
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
            if (!food.Any())
            {
                Console.WriteLine("No available foods at the moment!!!\nTry again later");
                return;
            }

            string choice = ViewAllFoodTypess();
            if (choice == string.Empty) return;


            int count = 0;
            Console.WriteLine("Viewing all available foods: ");
            System.Console.WriteLine($"FOODNAME    FOODPRICE");
            foreach (var foods in food.Where(food => food.FoodType.ToUpper() == choice.ToUpper()))
            {
                System.Console.WriteLine($"{++count}   {foods.FoodName}    {foods.Price}");
            }
        }

        public string ViewAllFoodTypess()
        {
            var foods = foodManager.GetAll().Select(food => food.FoodType).Distinct();
            int count = 0;
            Console.WriteLine("Viewing all food types: ");
            foreach (var food in foods)
            {
                Console.WriteLine($"{++count}. {food}");
            }
            Console.WriteLine("Choose food type (i.e enter 1,2,3,...): ");
            int choice = int.Parse(Console.ReadLine());
            if (choice < 1 || choice > foods.Count())
            {
                Console.WriteLine("Food Type chosen does not exist!!!");
                return string.Empty;
            }
            return foods.ToList()[--choice];
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