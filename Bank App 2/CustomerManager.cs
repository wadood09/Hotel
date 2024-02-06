using System.Globalization;

public class CustomerManager : ICustomerManager
{
    List<Customer> Customers = new List<Customer>();
    public Customer AddCustomer(Customer customer)
    {
        if(IsExist(customer.Email))
        {
            Console.WriteLine($"User with email {customer.Email} already exists");
        }
        else
        {
            Customers.Add(customer);
            Console.WriteLine($"Registration successfull,your account number is {customer.AccountNumber}");
        }
        return customer;
    }

    public void CreditWallet(double amount)
    {
        if(amount < 0)
        {
            Console.WriteLine("Amount can't be of negative value");
            return;
        }
        int loggedInUserId = Customer.LoggedInUserId;
        foreach (var customer in Customers)
        {
            if(customer.Id == loggedInUserId)
            {
                customer.WalletBalance += amount;
                Console.WriteLine($"Credited N{amount:n} successfully, your new wallet balance is N{customer.WalletBalance:n}");
            }
        }
    }

    public Customer Get(int id)
    {
        foreach (var customer in Customers)
        {
            if(customer.Id == id);
            {
                return customer;
            }
        }
        return null;
    }

    public Customer GetByAccountNo(string accountNo)
    {
        foreach (var customer in Customers)
        {
            if(customer.AccountNumber == accountNo);
            {
                return customer;
            }
        }
        return null;
    }

    public bool IsExist(string email)
    {
        foreach (var customer in Customers)
        {
            if(customer.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    public bool Login(string email, string password)
    {
        foreach (var customer in Customers)
        {
            if(customer.Email == email && customer.Password == password)
            {
                Customer.LoggedInUserId = customer.Id;
                return true;
            }
        }
        return false;
    }

    public void Transfer(int senderId, int receiverId, double amount)
    {
        foreach (var customer in Customers)
        {
            if(customer.Id == senderId)
            {
                customer.WalletBalance -= amount;
            }
            else if(customer.Id == receiverId)
            {
                customer.WalletBalance += amount;
            }
        }
    }
}