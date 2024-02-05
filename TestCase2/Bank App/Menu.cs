class Menu
{
    ICustomerManager _customerManager = new CustomerManager();
    public void MainMenu()
    {
        bool isContinue = true;
        Console.WriteLine("WELCOME TO MAZSTAR BANK");
        while (isContinue)
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                case 0:
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
    }

    public void CustomerMenu()
    {
        bool isContinue = true;
        var loggedInUser = _customerManager.Get(Customer.LoggedInUserId);
        Console.WriteLine($"Good afternoon {loggedInUser.LastName} {loggedInUser.FirstName}");
        while (isContinue)
        {
            Console.WriteLine("1. Credit Wallet");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. View Transaction History");
            Console.WriteLine("5. Account Details");
            Console.WriteLine("0. Logout");

            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 0:
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
    }

    private void Register()
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        Customer customer = new Customer(firstName, lastName, email, password);
        _customerManager.AddCustomer(customer);
    }

    private void Login()
    {
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (_customerManager.Login(email, password))
        {
            Console.WriteLine("Login Successful!");
            CustomerMenu();
        }
        else
        {
            Console.WriteLine("Invalid Login Details");
        }
    }
}