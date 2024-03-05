using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Enum;
using StudentFile_Project.Services.Implementations;
using StudentFile_Project.Services.Interfaces;

namespace StudentFile_Project.Menu
{
    public class MainMenu
    {
        IUserServices _userServ = new UserServices();
        IAdminServices _adminServ = new AdminServices();
        StudentMenu Studmenu = new StudentMenu();
        AdminMenu AdMenu = new AdminMenu();
        public void Main()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Student GradeBook");
                Console.WriteLine("1:Register");
                Console.WriteLine("2:Login");
                Console.WriteLine("0:Close");
                string userInput = Console.ReadLine()!;
                switch (userInput)
                {
                    case "1":
                        Register("STUDENT");
                        break;
                    case "2":
                        Login();
                        break;
                    case "0":
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public void Register(string role)
        {
            Console.WriteLine("Enter firstname");
            string firstName = Console.ReadLine()!;
            Console.WriteLine("Enter lastname");
            string lastName = Console.ReadLine()!;
            Console.WriteLine("Enter UserName");
            string userName = Console.ReadLine()!;
            Console.WriteLine("Enter email");
            string email = Console.ReadLine()!;
            Console.WriteLine("Enter password");
            string passWord = Console.ReadLine()!;
            Console.WriteLine("Enter Age ");
            int age = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter Gender (1:Male 2:Female)");
            int gender = int.Parse(Console.ReadLine()!);
            var form = _userServ.Create(email, userName, firstName, lastName, passWord, age, role, (Gender)gender);
            if (form is not null)
            {
                Console.WriteLine("Registration Successful");
            }
            else
            {
                Console.WriteLine("User with the email already exists");
            }

        }
        private void Login()
        {
            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine()!;
            Console.WriteLine("Enter your Password");
            string passWord = Console.ReadLine()!;
            var log = _userServ.IsLoggedIn(email, passWord);
            if (log is not null)
            {
                Console.WriteLine("Login Successful");
                if (log.Role == "STUDENT")
                {
                    Studmenu.MenuStudent();
                }
                else if (log.Role == "ADMIN")
                {
                    AdMenu.MenuAdmin();
                }
                else
                {
                    SuperMenu();
                }
            }
            else
            {
                Console.WriteLine("Invalid Login Credentials");
            }

        }

        public void SuperMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("SuperMenu");
                Console.WriteLine("1:Register Admin");
                Console.WriteLine("2:View All Admins");
                Console.WriteLine("3:Remove Admin");
                Console.WriteLine("0:LogOut");
                string userInput = Console.ReadLine()!;
                switch (userInput)
                {
                    case "1":
                        Register("ADMIN");
                        break;
                    case "2":
                        ViewAdmins();
                        break;
                    case "3":
                        RemoveAdmin();
                        break;
                    case "0":
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        private void ViewAdmins()
        {
            var getAll = _adminServ.GetAll();
            if (getAll.Count == 1)
            {
                Console.WriteLine("No Admin has Been Registered");
            }
            else
            {
                int count = 0;
                Console.WriteLine("Viewing All Admins");
                var admins = _userServ.GetAll().Where(user => user.Role == "ADMIN");
                Console.WriteLine($"NAME".PadRight(20) + $"USERNAME".PadRight(20) + $"GENDER".PadRight(20) + $"AGE".PadRight(20));
                foreach (var admin in admins)
                {
                    Console.WriteLine($"{++count}:{admin.FirstName} {admin.LastName}".PadRight(20) + $"{admin.UserName}".PadRight(20) + $"{admin.Gender}".PadRight(20) + $"{admin.Age}".PadRight(20));
                }
            }
        }
        private void RemoveAdmin()
        {
            ViewAdmins();
            Console.WriteLine("Choose Admin to be Removed (i.e enter 1,2,3,...)");
            int count = int.Parse(Console.ReadLine()!);
            if (count < 1 || count > _adminServ.GetAll().Count)
            {
                Console.WriteLine("Admin Chosen does not exist");
            }
            else
            {
                _adminServ.IsDeleted(_adminServ.GetAll()[--count].Id);
                Console.WriteLine("Successfully deleted Admin");
            }

        }

    }
}