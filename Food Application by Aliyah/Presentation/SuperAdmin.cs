using System;
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
        IDepositManager depositManager = new DepositManager();
        IOrderingManager orderingManager = new OrderingManager();
        Menu menu = new Menu();
        public void Admin()
        {
            Console.WriteLine(@"
                                Press 1. To View all Manager
                                Press 2. To View all Customers
                                Press 3. To Register a Manager
                                Press 4. To View All Orders
                                Press 0. To Log Out");
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
                    menu.Create("Manager");
                    Admin();
                    break;
                case 4:
                    ViewOrders();
                    Admin();
                    break;
                case 0:
                    menu.MainMenu();
                    break;
                default:
                    Console.WriteLine("Enter the correct input from the above list :");
                    break;
            }
        }
        public void ViewAllManager()
        {
            var manager = userManager.GetAll();
            if (!manager.Any(b => b.URole == "Manager"))
            {
                Console.WriteLine("No manager has been registered!!!");
                Console.WriteLine("Kindly please register manager in order to view managers!!!");
                return;
            }
            Console.WriteLine("Viewing all managers: ");
            int count = 0;
            foreach (var item in manager)
            {
                if (item.URole == "Manager")
                {
                    Console.WriteLine($"{++count}. {item.FirstName} {item.Lastname} {item.PhoneNumber} {item.Address} {item.Email} {item.PassWord} {item.URole}");

                }
            }
        }
        public void ViewAllCustomer()
        {
            var customer = userManager.GetAll();
            if (!customer.Any(b => b.URole == "Customer"))
            {
                Console.WriteLine("No customer has been registered yet!!!");
                return;
            }
            Console.WriteLine("Viewing all customers: ");
            int count = 0;
            foreach (var item in customer)
            {
                if (item.URole == "Customer")
                {
                    Console.WriteLine($"{++count}. {item.FirstName} {item.Lastname} {item.PhoneNumber}");
                }
            }
        }

        public void ViewOrders()
        {
            var orders = orderingManager.GetAllOrder();
            if(!orders.Any())
            {
                Console.WriteLine("No orders have been made!!!\nTry again later");
                return;
            }
            Console.WriteLine("Viewing all orders: ");
            int count = 0;
            foreach (var order in orders)
            {
                var wallet = walletManager.GetWallet(order.BuyerAccountNumber);
                var user = userManager.GetUser(wallet.Useremail);
                Console.WriteLine($"{++count}.  NAME: {user.FirstName} {user.Lastname} \nFOODNAME: {order.FoodName} \nFOODPRICE: {order.Price/order.Quantity} \nFOODQUANTITY: {order.Quantity} \nTOTALPRICE: {order.Price} \n TIME ORDERED: {order.CreatedAt}");
                Console.WriteLine();
            }
        }
    }
}