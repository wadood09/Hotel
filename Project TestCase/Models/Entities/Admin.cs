namespace Project_TestCase2.Models.Entities
{
    public class Admin : Auditables
    {
        static int AdminCount = 0;
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public static int LoggedInAdminId { get; set; }

        public Admin(string firstName, string lastname, string email, string password)
        {
            Id = ++AdminCount;
            FirstName = firstName;
            LastName = lastname;
            Email = email;
            Password = password;
        }
    }
}