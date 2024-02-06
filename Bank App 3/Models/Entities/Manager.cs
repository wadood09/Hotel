public class Manager : BaseEntity
{
    public string UserEmail {get; set;}
    public string Staffnumber {get; set;}
    public Manager(int sn, string userEmail, string staffNumber) : base(sn)
    {
        UserEmail = userEmail;
        Staffnumber = staffNumber;
    }
}