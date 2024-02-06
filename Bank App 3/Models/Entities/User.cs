public class User : BaseEntity
{
    public string Email {get; set;}
    public string Password {get; set;}
    public string Role {get; set;}
    public User(int sn, string email, string password, string role) : base(sn)
    {
        Email = email;
        Password = password;
    }
}