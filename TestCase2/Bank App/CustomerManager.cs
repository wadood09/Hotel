class CustomerManager : ICustomerManager
{
    List<Customer> Customers = new List<Customer>();
    public Customer AddCustomer(Customer customer)
    {
        if (IsExist(customer.Email))
        {
            Console.WriteLine($"User with email-{customer.Email} already Exists");
        }
        else
        {
            Customers.Add(customer);
            Console.WriteLine($"Registration Successfull!, your account number is {customer.AccountNumber}");
        }
        return customer;
    }

    public Customer Get(int id)
    {
         foreach (var customer in Customers)
        {
            if (customer.Id == id)
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
            if (customer.Email == email)
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
            if (customer.Email == email && customer.Password == password)
            {
                Customer.LoggedInUserId = customer.Id;
                return true;
            }
        }
        return false;
    }
}