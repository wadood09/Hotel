using System;
using System.Data.Common;
using Food_Application_Project;
using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Implementation;

public class User : Base
{
    public static int UserId { get; set; } = 0;
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PassWord { get; set; }
    public string URole { get; set; }
    public static string LoggedInUserEmail { get; set; }



    public User(string firstName, string lastName, string phoneNumber, string address, string email, string passWord, string role) : base()
    {
        UserId = FileContext.users.Count + 1;
        FirstName = firstName;
        Lastname = lastName;
        PhoneNumber = phoneNumber;
        Address = address;
        Email = email;
        PassWord = passWord;
        URole = role;

    }

    public User(int userId) : base()
    {
        UserId = UserId;
    }

    public override string ToString()
    {
        return $"{UserId}\t{CreatedAt}\t{FirstName}\t{Lastname}\t{PhoneNumber}\t{Address}\t{Email}\t{PassWord}\t{URole}";
    }

    public static User ToUser(string str)
    {
        var user = str.Split('\t');
        User user1 = new(UserId = int.Parse(user[0]))
        {
            CreatedAt = DateTime.Parse(user[1]),
            FirstName = user[2],
            Lastname = user[3],
            PhoneNumber = user[4],
            Address = user[5],
            Email = user[6],
            PassWord = user[7],
            URole = user[8]
        };
        return user1;
    }
}