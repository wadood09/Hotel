public class Customer
{
    public static int CustomerCount = 0;
    public static int LoggedInCustomerId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;} 
    public string Email {get; set;}
    public decimal TotalPriceOfStay {get; set;}
    public string Password {get; set;}
    public int ID {get; set;}
    public Customer(string firstName, string lastName, string email, string password)
    {
        ID = CustomerCount + 1;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        TotalPriceOfStay = 0;
        CustomerCount++;
    }
}