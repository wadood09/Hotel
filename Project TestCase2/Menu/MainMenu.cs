namespace Project_TestCase2.Menu
{
    public class Menu
    {
        AdminMenu adminMenu = new();
        CustomerMenu customerMenu = new();
        public void MainMenu()
        {
            bool isContinue = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            while (isContinue)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("==========WELCOME TO MY HOTEL MANAGEMENT APP==========");
                Console.WriteLine("1. ADMIN");
                Console.WriteLine("2. CUSTOMER");
                Console.WriteLine("0. EXIT");
                int choice = 3;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                switch (choice)
                {
                    case 1:
                        adminMenu.MainMenu();
                        break;
                    case 2:
                        customerMenu.MainMenu();
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
    }
}