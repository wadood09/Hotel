interface ICustomerManager
{
    public bool IsExist (string email);
    public Customer AddCustomer(Customer customer);
    public bool Login(string email, string password);
    public Customer Get(int id);
}