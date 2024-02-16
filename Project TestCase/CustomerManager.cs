class CustomerManager : IManager<Customer>
{
    static List<Customer> Customers = new List<Customer>();
    public Customer Add(Customer customer)
    {
        if(IsExist(customer.Email))
        {
            Console.WriteLine($"Customer with email {customer.Email} already exists");
        }
        else
        {
            Customers.Add(customer);
            Console.WriteLine("Registration Successfull");
        }
        return customer;
    }

    public void DeleteDetails(Customer value)
    {
        Customers.Remove(value);
    }

    public Customer Get(int id)
    {
        foreach (var customer in Customers)
        {
            if(customer.ID == id)
            {
                return customer;
            }
        }
        return null;
    }

    public List<Customer> GetList(int id)
    {
        throw new NotImplementedException();
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
                Customer.LoggedInCustomerId = customer.ID;
                return true;
            }
        }
        return false;
    }
}