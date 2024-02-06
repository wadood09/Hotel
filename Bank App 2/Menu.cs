public class Menu
{
    ICustomerManager _customerManager = new CustomerManager();
    ITransactionManager _transactionManager = new TransactionManager();
    public void MainMenu()
    {
        bool isContinue = true;
        Console.WriteLine("WELCOME TO MAZSTAR BANK");
        while (isContinue)
        {

            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
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
        Console.WriteLine($"Good afternoon {loggedInUser.FirstName} {loggedInUser.LastName}");
        while (isContinue)
        {
            Console.WriteLine("1. Credit Wallet");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. View Transaction History");
            Console.WriteLine("5. Account Details");
            Console.WriteLine("0. Logout");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreditWallet();
                    break;
                case 2:
                    Checkbalance();
                    break;
                case 3:
                    Transfer();
                    break;
                case 4:
                    ViewTransactionHistory();
                    break;
                case 5:
                    ViewAccountDetails();
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
        string lastname = Console.ReadLine();

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        Customer customer = new Customer(firstName, lastname, email, password);
        _customerManager.AddCustomer(customer);
        Read();
    }


    private void Login()
    {
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        if (_customerManager.Login(email, password))
        {
            Console.WriteLine("Login Successfull");
            CustomerMenu();
        }
        else
        {
            Console.WriteLine("Invalid Login Details");
            Read();
        }
    }


    private void CreditWallet()
    {
        Console.Write("Enter amount to be credited: ");
        double amount = int.Parse(Console.ReadLine());
        _customerManager.CreditWallet(amount);
        TransactionHistory history = new("Credit", $"You creditted your account with N{amount:n}", Customer.LoggedInUserId);
        _transactionManager.Add(history);
        Read();
        // Console.Clear();
    }


    private void Checkbalance()
    {
        var customer = _customerManager.Get(Customer.LoggedInUserId);
        Console.WriteLine($"Your Wallet Balance is N{customer.WalletBalance:n}");
        Read();
    }


    private void Read()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }


    private void Transfer()
    {
        Console.Write("Enter account number of user to transfer");
        string accountNo = Console.ReadLine();
        var customer = _customerManager.GetByAccountNo(accountNo);
        if (customer == null)
        {
            Console.WriteLine($"No user with account number {accountNo} is found");
            Read();
            return;
        }
        else
        {
            Console.WriteLine($"Are you sure you want to transfer to {customer.FirstName} {customer.LastName} (y/n)");
            char choice = char.Parse(Console.ReadLine().ToLower());
            var loggedInCustomer = _customerManager.Get(Customer.LoggedInUserId);
            if (choice == 'y')
            {
                Console.Write($"Enter amount to be transferred to {customer.FirstName} {customer.LastName}");
                double amount = double.Parse(Console.ReadLine());
                if (amount > loggedInCustomer.WalletBalance)
                {
                    Console.WriteLine("Insufficient Balance!");
                    Read();
                }
                else
                {
                    _customerManager.Transfer(loggedInCustomer.Id, customer.Id, amount);
                    Console.WriteLine($"You have successfully transferred N{amount:n} to {customer.FirstName} {customer.LastName}");
                    TransactionHistory sendHistory = new TransactionHistory("Debit", $"You transfered N{amount:n} to {customer.FirstName} {customer.LastName}", Customer.LoggedInUserId);
                    TransactionHistory receiveHistory = new TransactionHistory("Credit", $"{loggedInCustomer.FirstName} {loggedInCustomer.LastName} transferred N{amount:n} to you", customer.Id);
                    _transactionManager.Add(sendHistory);
                    _transactionManager.Add(receiveHistory);
                    Read();
                }
            }
        }
    }


    private void ViewAccountDetails()
    {
        var customer = _customerManager.Get(Customer.LoggedInUserId);
        Console.WriteLine($"Account number: {customer.AccountNumber}");
        Console.WriteLine($"Account name: {customer.FirstName} {customer.LastName}");
        Console.WriteLine($"Joined since: {customer.CreatedAt.ToString("dddd, dd, MMM, yyy")}");
        Read();
    }


    private void ViewTransactionHistory()
    {
        var histories = _transactionManager.GetbyCustomerId(Customer.LoggedInUserId);
        if (histories.Count == 0)
        {
            Console.WriteLine("Transaction History is empty");
        }
        foreach (var history in histories)
        {
            Console.ForegroundColor = history.Title.ToLower() == "credit" ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{history.Title.ToUpper()}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\t\t {history.CreatedAt.ToString("MMM, dd, yyy")}");
            Console.WriteLine($"{history.Description}");
            Console.WriteLine();
        }
        Read();
    }
}