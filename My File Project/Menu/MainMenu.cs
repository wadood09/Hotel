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
        IBookingService _bookingService = new BookingService();
        GeneralMenu generalMenu = new();
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
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void Register()
        {
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

        private void LoginAs()
        {
            Console.WriteLine("Login as: ");
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
                    LoginAsAdmin();
                    break;
                case 2:
                    LoginAsCustomer();
                    break;
                default:
                    Console.WriteLine("Invalid Input!!!");
                    break;
            }
        }

        private void Register(string role)
        {
            Console.Write("Enter your first name: ");
            string? firstName = null;
            generalMenu.EnterChoice(ref firstName);

            Console.Write("Enter your last name: ");
            string? lastName = null;
            generalMenu.EnterChoice(ref lastName);

            Console.Write("Enter your date of birth (yyyy/mm/dd): ");
            DateTime dob = DateTime.Parse("01/01/1800");
            while (dob == DateTime.Parse("01/01/1800"))
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime choice))
                {
                    dob = choice;
                }
                else
                {
                    Console.WriteLine("Invalid Format for Date of Birth!!!\nTry again: ");
                }
            }

            Console.Write("Enter your email: ");
            string? email = null;
            generalMenu.EnterChoice(ref email);

            Console.Write("Enter your password: ");
            string? password = null;
            generalMenu.EnterChoice(ref password);

            User? user = _userService.CreateUser(firstName!, lastName!, dob, email!, password!, role);
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
            if (login.Item1 == true)
            {
                User.LoggedInUserEmail = login.Item2[0].Email;
                Console.WriteLine("Login Successfull!!!");
                Read();
                if (login.Item2.Count == 1)
                {
                    if (login.Item2![0].Role == "ADMIN")
                    {
                        LoginAsAdmin();
                    }
                    else
                    {
                        LoginAsCustomer();
                    }
                }
                else
                {
                    LoginAs();
                }
            }
            else
            {
                Console.WriteLine("Invalid login Credential details!!!");
                Read();
            }
        }

        private void LoginAsAdmin()
        {
            Admin admin = _adminService.Get(admin => admin.UserEmail == User.LoggedInUserEmail)!;
            Admin.LoggedInAdminId = admin.Id;
            generalMenu.CheckHotelStatus();
            adminMenu.MainMenu();
        }

        private void LoginAsCustomer()
        {
            Customer customer = _customerService.Get(customer => customer.UserEmail == User.LoggedInUserEmail)!;
            Customer.LoggedInCustomerId = customer.Id;
            generalMenu.CheckHotelStatus();
            generalMenu.CustomerStatus();
            List<Booking> bookings = _bookingService.GetSelected(booking => booking.CustomerID == customer.Id);
            foreach (Booking booking in bookings)
            {
                if(booking.CustomerStatus == Models.Enums.Status.Inactive)
                {
                    customerMenu.CheckOut(booking);
                }
            }
            customerMenu.MainMenu();
        }

        private void Read()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}