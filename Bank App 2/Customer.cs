public class Customer : Base
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public double WalletBalance { get; set; }
    public string AccountNumber { get; set; }
    public static int LoggedInUserId {get;set;}
    public static int CustomerCount = 0;
    public Customer(string firstName, string lastname, string email, string password)
    {
        Id = CustomerCount + 1;
        FirstName = firstName;
        LastName = lastname;
        Email = email;
        Password = password;
        WalletBalance = 0;
        AccountNumber = GenerateAccountNumber();
        CreatedAt = DateTime.Now;
        CustomerCount++;
    }
    private string GenerateAccountNumber()
    {
        Random random = new();
        int num = random.Next(10000, 100000);
        return $"{FirstName[0]}{LastName[0]}{num}".ToUpper();
    }
}