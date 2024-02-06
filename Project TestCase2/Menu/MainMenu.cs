namespace Project_TestCase2.Menu
{
    public class Menu
    {
        AdminMenu adminMenu = new();
        CustomerMenu customerMenu = new();
        public void MainMenu()
        {
            bool isContinue = true;
            Console.WriteLine("WELCOME");
            while (isContinue)
            {
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
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }
    }
}