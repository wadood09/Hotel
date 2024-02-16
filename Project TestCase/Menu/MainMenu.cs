namespace Project_TestCase2.Menu
{
    public class Menu
    {
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