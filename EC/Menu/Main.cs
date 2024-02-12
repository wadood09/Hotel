using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Enums;
using EC.Services.Implementations;
using EC.Services.Interfaces;

namespace EC.Menu
{
    public class Main
    {
        IUserService userService = new UserService();
        ICustomerService customerService = new CustomerService();
        public void MainMenu()
        {
            System.Console.WriteLine("enter 1 to register");
            System.Console.WriteLine("enter 2 to login");
            int opt = int.Parse(Console.ReadLine());
            if(opt == 1)
            {
                RegisterMenu();
                MainMenu();
            }
            else if(opt == 2)
            {
                LoginMenu();
            }
            else
            {
                System.Console.WriteLine("wrong input");
                MainMenu();
            }
        }

        public void RegisterMenu()
        {
            Console.Write("enter your email: ");
            string? email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();

            Console.Write("enter your first name: ");
            string? fName = Console.ReadLine();

            Console.Write("enter your lass name: ");
            string lName = Console.ReadLine();

            Console.Write("enter your phone number: ");
            string? phone = Console.ReadLine();

            Console.Write("enter your address: ");
            string address = Console.ReadLine();

            Console.Write("enter 1 for male and 2 for female: ");
            int gender = int.Parse(Console.ReadLine());

            var rsp = customerService.RegisterCustomer(email,pass,fName,lName,phone,address,(Gender)gender);
            if(rsp != null)
            {
                System.Console.WriteLine("Congratulations");
            }
        }

        public void LoginMenu()
        {
            Console.Write("enter your email: ");
            string? email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();

            var response = userService.Login(email, pass);
            if(response == null)
            {
                System.Console.WriteLine("invalid cridentials");
                LoginMenu();
            }
            if(response.Role == "SuperAdmin")
            {
                Super s = new Super();
                s.SuperMenu();
            }
            else if (response.Role == "Manager")
            {

            }
            else if (response.Role == "Customer")
            {

            }

        }
    }
}