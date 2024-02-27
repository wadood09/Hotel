// using System.Runtime.CompilerServices;

using System.IO.Pipes;
using Food_Application_Project;
using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Implementation;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Presentation;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

class Menu
{
    IUserManager userManager = new UserManager();
    IWalletManager walletManager = new WalletManager();
    IDepositManager depoMan = new DepositManager();
    IOrderingManager orderMan = new OrderingManager();
    IFoodManager foodManager = new FoodManager();


    User currentUser = null;


    public void MainMenu()
    {

        bool isContinue = true;
        Console.WriteLine("<<<<WELCOME TO MAYOR'S BUKA>>>>");
        while (isContinue)
        {
            Console.WriteLine("Press 1. To Register");
            Console.WriteLine("Press 2. To Login");
            Console.WriteLine("Press 3. To Exit");
            int Input = int.Parse(Console.ReadLine());
            switch (Input)
            {
                case 1:
                    Create("Customer");
                    break;
                case 2:
                    var currentLoggedIn = userManager.GetLoggedINUser(Login());

                    if (currentLoggedIn != null)
                    {
                        Console.WriteLine("Login Successfull!!!");
                        if (currentLoggedIn.URole == "Customer")
                        {
                            CustomerMenu customerMenu = new CustomerMenu();
                            customerMenu.Customer(currentLoggedIn.Email);
                        }
                        else if (currentLoggedIn.URole == "Manager")
                        {
                            ManagerMenu managerMenu = new ManagerMenu();
                            managerMenu.Manager();
                        }
                        else if (currentLoggedIn.URole == "SuperAdmin")
                        {
                            SuperAdmin superAdmin = new SuperAdmin();
                            superAdmin.Admin();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not found");
                    }

                    break;
                case 3:
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    public void Create(string role)
    {
        Console.WriteLine("Enter FirstName");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter LastName");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter PhoneNumber");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter Email");
        string email = Console.ReadLine();
        System.Console.WriteLine("Enter Password");
        string passWord = Console.ReadLine();
        Console.WriteLine("Enter Address");
        string address = Console.ReadLine();
        DateTime dateCreated = DateTime.Now;
        var users = userManager.Create(firstName, lastName, phoneNumber, address, email, passWord, role);
        Wallet wallet = new Wallet(email, phoneNumber);
        if (wallet == null)
        {
            Console.WriteLine("Registration Unsuccessfull!!!");
            return;
        }
        if (users != null)
        {
            walletManager.AddWallet(wallet);
            Console.WriteLine($"Registration Successfull");
            if(role == "Manager") return;
            Console.WriteLine($"Your wallet account no is {wallet.AccountNumber}");
        }
        else
        {
            System.Console.WriteLine($"User with email {email} already exists");
        }
    }
    private User Login()
    {

        User useR = null;
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        var user = userManager.Login(email, password);

        if (user != null)
        {
            User.LoggedInUserEmail = email;
            useR = user;
        }
        return useR;
    }
    public string GenerateId()
    {
        Random random = new Random();
        string num = random.Next(1, 10).ToString();
        return num;
    }
}

