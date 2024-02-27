using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Implementation;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Presentation
{
    public class SuperAdmin
    {
        IUserManager userManager = new UserManager();
        IWalletManager walletManager = new WalletManager();
        IWalletRepository walletRepo = new WalletRepository();
        IManagerManage managerManager = new ManagerManage();
        public void Admin()
        {
            Console.WriteLine(@"Press 1. To View all Manager
                                Press 2. To View all Customers
                                Press 3. To Register a Manager
                                Press 4. To Deposit Into your Account
                                Press 5. To View all Balance
                                Press 6. To Log Out
                                Press 7. To View All Customers Transaction");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                ViewAllManager();
                Admin();
                break;
                case 2: 
                ViewAllCustomer();
                Admin();
                break;
                case 3: 
                RegisterManager();
                Admin();
                break;
                case 4: 
                DepositAccount();
                Admin();
                break;
                case 5: 
                ViewAvailableBalance();
                Admin();
                break;
                case 6:
                Menu menu = new Menu();
                menu.MainMenu();
                break;
                default:
                System.Console.WriteLine("Enter the correct input from the above list :");
                break;
            }
        }
        public void ViewAllManager()
        {
            var manager = userManager.GetAll();
            foreach (var item in manager)
            {
                if (item.URole == "Manager")
                {
                    Console.WriteLine($"{item.FirstName} {item.Lastname} {item.PhoneNumber} {item.Address} {item.Email} {item.PassWord} {item.URole}");

                }
            }
        }
        public void ViewAllCustomer()
        {
            var customer = userManager.GetAll();
            foreach (var item in customer)
            {
                if (item.URole == "Customer")
                {
                    System.Console.WriteLine($"{item.FirstName} {item.Lastname} {item.PhoneNumber} {item.Address} {item.Email} {item.PassWord} {item.URole}");

                }
            }
        }
        public void RegisterManager()
        {
            System.Console.WriteLine("Enter your name");
            string firstName = Console.ReadLine();
            System.Console.WriteLine("Enter your lastName");
            string lastName = Console.ReadLine();
            System.Console.WriteLine("Enter your PhoneNumber");
            string phoneNumber = Console.ReadLine();
            System.Console.WriteLine("Enter your address");
            string address = Console.ReadLine();
            System.Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();
            System.Console.WriteLine("Enter your PassWord");
            string passWord = Console.ReadLine();
            DateTime date = DateTime.Now;
           

            var users = userManager.CreateManager(firstName, lastName, phoneNumber, address, email, passWord, "Manager");
            var manager = userManager.GetUser(users.Email);
            if (manager != null)
            {
                Wallet adminWallet = new Wallet(manager.Email, manager.PhoneNumber);
                walletRepo.AddWallet(adminWallet);
                Console.WriteLine("Manager Successfully Created :");
            }
        }
        public void DepositAccount()
        {
            System.Console.WriteLine("Enter your accountDetails :");
            string managerwallet = "123490";
            var manager = userManager.GetUser(managerwallet);
            if (manager != null)
            {
                System.Console.WriteLine("Account has been Credited");
            }
            else
            {
                System.Console.WriteLine("Invalid Account Details");
            }
        }
        public void ViewAvailableBalance()
        {
           System.Console.WriteLine("Enter your Account Number: ");
           string acct = Console.ReadLine();
           System.Console.WriteLine("Enter your email");
           string mail = Console.ReadLine();
           var wall = walletManager.CheckWallet(mail,acct);
          System.Console.WriteLine($"Your account balance is {wall}");
        }
    }
}