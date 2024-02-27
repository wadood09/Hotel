using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Manager.Implementation;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Presentation
{
    public class ManagerMenu
    {
        IFoodManager foodManager = new FoodManager();
        IUserManager userManager = new UserManager();
        IWalletManager walletManager = new WalletManager();

        public void Manager()
        {
            Console.WriteLine(@"Press 1. To Add Food
                                Press 2. To view all existing customers
                                Press 3. To view all foods
                                Press 4. To view available balance
                                Press 5. To log out");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                AddFood();
                Manager();
                break;
                case 2:
                ViewAllCustomer();
                Manager();
                break;
                case 3:
                ViewAllFoods();
                Manager();
                break;
                case 4:
                ViewAvailableBalance();
                Manager();
                break;
                case 5:
                Menu menu = new Menu();
                menu.MainMenu();
                break;
                default:
                System.Console.WriteLine("Enter the correct number in the above list :");
                break;
            } 
        }
        public void AddFood()
        {
            Console.WriteLine("Enter the name of the food you want to add :");
            string foodName = Console.ReadLine();
            Console.WriteLine("Enter the type of food :");
            string foodType = Console.ReadLine();
            System.Console.WriteLine("Enter the price of the food :");
            double price = double.Parse(Console.ReadLine());
            DateTime date = DateTime.Now;
            var foods = foodManager.CreateFood(foodName,price,foodType);
            if (foods != null)
            {
                System.Console.WriteLine("Food added successfully !!!");
            }
        }
        public void ViewAllCustomer()
        {
            var user = userManager.GetAll();
            foreach (var item in user)
            {
                if (item.URole == "Customer")
                {
                    System.Console.WriteLine($"{item.FirstName} {item.Lastname} {item.PhoneNumber} {item.Address} {item.Email} {item.PassWord} {item.URole} :");

                }
            }
        }
        public void ViewAllFoods()
        {
            var foods = foodManager.GetAll();
            foreach (var item in foods)
            {
                System.Console.WriteLine($"{item.FoodName} {item.Price} {item.FoodType}");
            }
        }
        public void ViewAvailableBalance()
        {
            var balance = walletManager.GetWallets();
            foreach (var item in balance)
            {
                System.Console.WriteLine($"{item.Amount} {item.Useremail}");
            }
        }
        
    }
}