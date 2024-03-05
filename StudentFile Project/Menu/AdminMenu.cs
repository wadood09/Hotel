using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Services.Implementations;
using StudentFile_Project.Services.Interfaces;

namespace StudentFile_Project.Menu
{
    public class AdminMenu
    {
        IAdminServices _adminServ = new AdminServices();
        IStudentServices _studentServ = new StudentServices();
        IUserServices _userServ = new UserServices();
        public void MenuAdmin()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Admin's Menu");
                Console.WriteLine("1:View All Students");
                Console.WriteLine("2:Remove Student");
                Console.WriteLine("0:Exit");
                string userInput = Console.ReadLine()!;
                switch (userInput)
                {
                    case "1":
                        ViewAllStudent();
                        break;
                    case "2":
                        RemoveStudent();
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
        private void ViewAllStudent()
        {
            int count = 0;
            Console.WriteLine("Students");
            foreach (var item in _studentServ.GetAll())
            {
                var user = _userServ.GetByEmail(item.UserEmail);
                System.Console.WriteLine($"{++count} {user.Id} {user.FirstName} {user.LastName} {user.Age} {user.Email} {user.Gender} {user.UserName} {user.Role}");
            }

        }
        private void RemoveStudent()
        {
            ViewAllStudent();
            Console.WriteLine("Choose Student you want to Remove(i.e Enter 1,2,3...)");
            int count = int.Parse(Console.ReadLine()!);
            if (count < 1 || count > _studentServ.GetAll().Count)
            {
                Console.WriteLine("Student does not exists");
            }
            else
            {
                _studentServ.IsDeleted(_studentServ.GetAll()[--count].UserEmail);
                Console.WriteLine("Student successfully Deleted");
            }

        }

    }
}