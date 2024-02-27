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
            Console.WriteLine("Press 1. To Create a User");
            Console.WriteLine("Press 2. To Login");
            Console.WriteLine("Press 3. To Exit");
            int Input = int.Parse(Console.ReadLine());
            switch (Input)
            {
                case 1:
                    Create();
                    break;
                case 2:
                    var currentLoggedIn = userManager.GetLoggedINUser(Login());
                    
                    if(currentLoggedIn != null)
                    {
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
                        Login();
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

    private void Create()
    {
        Console.WriteLine("1.Press to register as a Customer\n2.Press to register as a Manager");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
                Console.WriteLine("Enter your FirstName");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter your LastName");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your PhoneNumber");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter your Email");
                string email = Console.ReadLine();
                System.Console.WriteLine("Enter your Password");
                string passWord = Console.ReadLine();
                Console.WriteLine("Enter your Address");
                string address = Console.ReadLine();
                DateTime dateCreated = DateTime.Now;
                foreach (var roles in Enum.GetValues(typeof(Role)))
                {
                    if ((int)roles == 3)
                    {
                        break;
                    }
                    Console.WriteLine($"Enter {(int)roles}. {roles}");
                }
                int role = int.Parse(Console.ReadLine());
                var users = userManager.CreateUser(firstName,lastName,phoneNumber,address,email,passWord);
                Wallet wallet = new Wallet(email, phoneNumber);  
                if(wallet == null)
                {
                    Console.WriteLine("You've not created a wallet account!!!");
                    return;
                }
                // string acctNum = wallet.AccountNumber;
                if (users != null)
                {
                    walletManager.AddWallet(wallet);
                    Console.WriteLine($" {firstName} {lastName} Creation was Sucessful!!! \n Your wallet account no is {wallet.AccountNumber}");
                }
                else
                {
                    System.Console.WriteLine("Customer already exists");
                }

        }
        else if (choice == 2)
        {
            System.Console.WriteLine("Sorry you can not register here Kindly meet the Super Admin :");
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
            useR = user;
        }
        return useR;
    }
    public string GenerateId()
    {
        Random random = new Random();
        string num = random.Next(1,10).ToString();
        return num;
    }
}

