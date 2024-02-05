namespace Project_TestCase2.Models.Entities
{
    public class Customer : Auditables
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal TotalPriceOfStay { get; set; }
        public static int LoggedInCustomerId { get; set; }
        static int CustomerCount = 0;

        public Customer(string firstName, string lastname, string email, string password)
        {
            Id = ++CustomerCount;
            FirstName = firstName;
            LastName = lastname;
            Email = email;
            Password = password;
            IsDeleted = false;
        }
    }
}