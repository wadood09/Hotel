using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Enum;
using StudentFile_Project.Services.Implementations;
using StudentFile_Project.Services.Interfaces;

namespace StudentFile_Project.Menu
{
    public class Menu
    {
        MainMenu menu = new MainMenu();
        IAdminServices _adminServ = new AdminServices();
        IUserServices _userServ = new UserServices();
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
                        menu.Register("ADMIN");
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
            int count = 0;
            Console.WriteLine("Viewing All Admins");
            var admins = _userServ.GetAll().Where(user => user.Role == "ADMIN");
            Console.WriteLine($"NAME".PadRight(20) + $"USERNAME".PadRight(20) + $"GENDER".PadRight(20) + $"AGE".PadRight(20));
            foreach (var admin in admins)
            {
                Console.WriteLine($"{++count}:{admin.FirstName} {admin.LastName}".PadRight(20) + $"{admin.UserName}".PadRight(20) + $"{admin.Gender}".PadRight(20) + $"{admin.Age}".PadRight(20));
            }
        }
        private void RemoveAdmin()
        {
            ViewAdmins();
            Console.WriteLine("Choose Admin to be Removed (i.e enter 1,2,3,...)");
            int count = int.Parse(Console.ReadLine()!);
            if (count < 1 || count > _adminServ.GetAll().Count)
            {
                Console.WriteLine("Admin does not exist");
            }
            else
            {
                _adminServ.IsDeleted(_adminServ.GetAll()[--count].Id);
                Console.WriteLine("Succefully deleted Admin");
            }

        }


    }
}