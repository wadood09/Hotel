public class Profile : BaseEntity
{
    public string UserEmail;
    public string FirstName;
    public string LastName;
    public string PhoneNumber;
    public string Address;
    public Gender Gender;
    public DateTime Date;
    public Profile(int sn, string userEmail, string firstName, string lastName, string phoneNumber, string address, Gender gender) : base(sn)
    {
        UserEmail = userEmail;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Address = address;
        Gender = gender;
    }
}