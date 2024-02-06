// See https://aka.ms/new-console-template for more information


using System.Collections;
using System.Xml.Serialization;




Console.WriteLine("Welcome to MyBank App");
Customer customer = new();
var registrationDetails = GetRegistrationDetails();
customer.FirstName = registrationDetails.Item1;
customer.LastName = registrationDetails.Item2;
customer.Age = registrationDetails.Item3;
customer.PhoneNo = registrationDetails.Item4;
customer.BVN_NIN = registrationDetails.Item5;
customer.Balance = 0.00;


if (customer.Age == 0)
{

}
else
{
    Random random = new();
    customer.OTP = random.Next(1000, 10000);
    Console.WriteLine($"OTP has been sent to phone number.\nEnter within one minute to verify it is you.");
    Console.WriteLine(customer.OTP);
    DateTime currentTime = DateTime.Now;
    DateTime x1MinLater = currentTime.AddMinutes(1);
    int verify = int.Parse(Console.ReadLine());
    DateTime compareTime = DateTime.Now;
    if (compareTime > currentTime && compareTime < x1MinLater)
    {
        if (verify == customer.OTP)
        {
            int store = 2;
            customer.AccountNo = long.Parse(customer.PhoneNo);
            customer.Password = customer.GeneratePassword();
            Console.WriteLine($"Welcome {customer.FirstName} {customer.LastName},Your account number is {customer.AccountNo},and your password is {customer.Password}");
            Console.WriteLine("Enter amount to be stored");
            int amount = int.Parse(Console.ReadLine());
            if (amount > 50000 && customer.BVN_NIN == "")
            {
                Console.WriteLine("Your account limit is $50,000.Enter BVN/NIN to increase limit");
                Console.WriteLine("To enter BVN/NIN,Press 1.To skip this process,Press 2");
                int choice1 = int.Parse(Console.ReadLine());
                if (choice1 == 1)
                {
                    Console.WriteLine("Enter BVN/NIN: ");
                    customer.BVN_NIN = Console.ReadLine();
                    customer.CheckBVN();
                }
                if (customer.BVN_NIN.Length != 11 || choice1 == 2)
                {
                    Console.WriteLine("Enter amount to be stored.(Must be less than $50000)");
                    amount = int.Parse(Console.ReadLine());
                    if (amount <= 50000)
                    {
                        store = 2;
                    }
                    else
                    {
                        store = 0;
                        Console.WriteLine("Amount has passed account limit!!! GOODBYE");
                    }
                }
            }
            customer.Balance += amount;
            if (amount < 1000)
            {
                Console.WriteLine($"Acount balance is ${customer.Balance}.\nAccount balance must not be less than 1000.\nPress 1 to top up,2 to exit");
                int choice1 = int.Parse(Console.ReadLine());
                if (choice1 == 1)
                {
                    Console.WriteLine("Enter amount to be added to balance");
                    customer.Balance += int.Parse(Console.ReadLine());
                }
                else
                {
                    store = 0;
                    Console.WriteLine("Goodbye");
                }
            }
            if (customer.Balance >= 1000 && store > 0)
            {
                double commission = customer.Balance * 2 / 100;
                double newBalance = customer.Balance - commission;
                Console.WriteLine($"Your balance is ${newBalance}");
            }
            if (store > 0)
            {
                Console.WriteLine("Press 1 to withdraw,2 to exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    AccessWithdarawal(customer.Balance, customer.Password);
                }
                else
                {
                    Console.WriteLine("GOODBYE");
                }
            }


        }
        else
        {
            Console.WriteLine("OTP inputted is not correct.Try again later");
        }
    }
    else
    {
        Console.WriteLine("OTP has expired.Try again later");
    }

}








static bool CheckAge(int age)
{
    if (age < 18)
    {
        return true;
    }
    else
    {
        return false;
    }
}






static bool CheckPhoneNumber(string phoneNo)
{
    if (phoneNo.Length == 11 || phoneNo.Length == 10)
    {
        return true;
    }
    else return false;
}








static void AccessWithdarawal(double balance, string userPassword)
{
    Console.Write("Enter amount to withdraw: ");
    double withdraw = double.Parse(Console.ReadLine());
    Console.Write("Enter password: ");
    string password = Console.ReadLine();
    int count = 5;

    if (password == userPassword)
    {
        Console.WriteLine($"Your current balance is ${balance - withdraw}");
    }
    else
    {
        Console.WriteLine("Incorrect password,Try again");
        while (count > 0 && password != userPassword)
        {
            password = Console.ReadLine();
            if (password == userPassword)
            {
                Console.WriteLine($"Your current balance is ${balance - withdraw}");
                return;
            }
            count--;
            if (count > 0)
            {
                Console.WriteLine($"You have {count} chances left");
            }
        }
        if (count == 0)
        {
            Console.WriteLine("Too many attempts,Try again later");
        }
    }

}











static (string, string, int, string, string) GetRegistrationDetails()
{
    Console.Write("Enter first name: ");
    string firstName = Console.ReadLine();
    Console.Write("Enter last name: ");
    string lastName = Console.ReadLine();
    Console.Write("Enter age: ");
    int age = int.Parse(Console.ReadLine());
    if (CheckAge(age) == true)
    {
        Console.WriteLine($"\tHello {firstName} {lastName}.\nYou are under 18 and are not elligible to own a bank account.Request help from Parent/Guardian");
        return ("", "", 0, "", "");
    }
    Console.Write("Enter phone number (+234): ");
    string phoneNo = Console.ReadLine();
    int count = 4;
    if (CheckPhoneNumber(phoneNo) == false)
    {
        Console.WriteLine("Phone number is invalid!!! Try again ");
        while (CheckPhoneNumber(phoneNo) == false && count > 0)
        {
            phoneNo = Console.ReadLine();
            if (CheckPhoneNumber(phoneNo) == true)
            {
                break;
            }
            count--;
            if (count == 0)
            {
                Console.WriteLine("Too many incorrect attempts!!! Try again later");
                break;
            }
            Console.WriteLine($"You have {count} chances left");
        }
        if (count == 0)
        {
            return ("", "", 0, "", "");

        }
    }
    Console.Write("Enter BVN/NIN (optional): ");
    string bvn_nin = Console.ReadLine();
    return (firstName, lastName, age, phoneNo, bvn_nin);
}










public class Customer
{
    private string firstName;
    private string lastName;
    private int age;
    private string phoneNo;
    private long accountNo;
    private string bvn_nin;
    private int otp;
    private double balance;
    private string password;

    public string FirstName
    {
        set { firstName = value; }
        get { return firstName; }
    }
    public string LastName
    {
        set { lastName = value; }
        get { return lastName; }
    }
    public int Age
    {
        set { age = value; }
        get { return age; }
    }
    public string PhoneNo
    {
        set { phoneNo = value; }
        get { return phoneNo; }
    }
    public long AccountNo
    {
        set { accountNo = value; }
        get { return accountNo; }
    }
    public string BVN_NIN
    {
        set { bvn_nin = value; }
        get { return bvn_nin; }
    }
    public int OTP
    {

        set { otp = value; }
        get { return otp; }
    }
    public double Balance
    {
        set { balance = value; }
        get { return balance; }
    }
    public string Password
    {
        set { password = value; }
        get { return password; }
    }

    public string GeneratePassword()
    {
        {
            Random rand = new();
            int num = rand.Next(1000, 10000);
            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var pos1 = rand.Next(0, alpha.Length);
            var pos2 = rand.Next(0, alpha.Length);
            var letters = $"{alpha[pos1]}{alpha[pos2]}";
            return $"{num}{letters}";
        }
    }


    public void CheckBVN()
    {
        if (bvn_nin.Length != 11)
        {
            Console.WriteLine("BVN is invalid!!! \nBVN must be of 11 digits!!! Try again");
            int count = 4;
            while (count > 0 && bvn_nin.Length != 11)
            {
                bvn_nin = Console.ReadLine();
                if (bvn_nin.Length == 11)
                {
                    return;
                }
                count--;
                if (count == 0)
                {
                    Console.WriteLine("Too many incorrect attempts!!! Try again later");
                    return;
                }
                Console.WriteLine($"You have {count} chances left");

            }
        }
        else
        {
            return;
        }
    }




}
