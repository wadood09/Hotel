using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;
using My_File_Project.Services.Implementation;
using My_File_Project.Services.Interface;

namespace My_File_Project.Menu
{
    public class Menu
    {
        IAdminService _adminService = new AdminService();
        ICustomerService _customerService = new CustomerService();
        IUserService _userService = new UserService();
        AdminMenu adminMenu = new();
        CustomerMenu customerMenu = new();
        Random random = new();
        ConsoleColor[] colours = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White };
        public void MainMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("========== WELCOME TO MY HOTEL MANAGEMENT SYSTEM ==========");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");
                int choice = 3;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                switch (choice)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void Register()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Register as: ");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            int choice = 3;
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                choice = num;
            }
            switch (choice)
            {
                case 1:
                    Register("ADMIN");
                    break;
                case 2:
                    Register("CUSTOMER");
                    break;
                default:
                    Console.WriteLine("Invalid Input!!!");
                    break;
            }
        }

        private void Register(string role)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Enter your date of birth (dd/mm/yyyy): ");
            DateTime dob = DateTime.Parse("01/01/1800");
            while (dob == DateTime.Parse("01/01/1800"))
            {
                if (DateTime.TryParse($"{Console.ReadLine(): dd/mm/yyyy}", out DateTime choice))
                {
                    dob = choice;
                }
                else
                {
                    Console.WriteLine("Invalid Format for Date of Birth!!!\nTry again: ");
                }
            }

            Console.Write("Enter your email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter your password: ");
            string password = Console.ReadLine()!;

            User? user = _userService.CreateUser(firstName, lastName, dob, email, password, role);
            if (user is null)
            {
                Console.WriteLine($"Email {email} already exists!!!");
                Console.WriteLine($"Registration failed!!!");
            }
            else
            {
                Console.WriteLine("Registration successfull!!!");
            }
            Read();
        }

        private void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            var login = _userService.Login(email, password);
            if(login.Item1 == true)
            {
                User.LoggedInUserId = login.Item2!.Id;
                Console.WriteLine("Login Successfull!!!");
                Read();
                if(login.Item2!.Role == "ADMIN")
                {
                    Admin admin = _adminService.Get(admin => admin.UserId == User.LoggedInUserId)!;
                    Admin.LoggedInAdminId = admin.Id;
                }
                else if(login.Item2.Role == "CUSTOMER")
                {
                    Customer customer = _customerService.Get(customer => customer.UserId == User.LoggedInUserId)!;
                    Customer.LoggedInCustomerId = customer.Id;
                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine("Invalid login Credential details!!!");
                Read();
            }
        }

        private void Read()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}