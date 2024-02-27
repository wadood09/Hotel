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
             var form = _userServ.Create(email,userName,firstName,lastName,passWord,age,role,(Gender)gender);
             if(form is not null)
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
             var log = _userServ.IsLoggedIn(email,passWord);
             if(log is not null)
             {
                Console.WriteLine("Login Successful");
                if(log.Role == "STUDENT")
                 {
                    Studmenu.MenuStudent();
                 }
                 else
                 {
                    AdMenu.MenuAdmin();
                 }
             }
             else
             {
                Console.WriteLine("Invalid Login Credentials");
             }

        }
    }
}