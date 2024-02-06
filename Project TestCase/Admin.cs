public class Admin
{
    public static int AdminCount = 0;
    public static int LoggedInAdminId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int ID {get; set;}
    public Admin(string firstName, string lastName, string email, string password)
    {
        ID = AdminCount + 1;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        AdminCount++;
    }
}