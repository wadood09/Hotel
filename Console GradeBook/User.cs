using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class User
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string UserName { get; set; }
  public string Password { get; set; }
  public double BiologyScore { get; set; }
  public double ChemistryScore { get; set; }
  public double Overall { get; set; }
  public string Grade { get; set; }
   static List<User> Users = new List<User>();
   public bool IsExamDone = false;
  public static User LogggedInUser { get; set; }

  public User(string firstname, string lastname, string username, string password)
  {
    FirstName = firstname;
    LastName = lastname;
    UserName = username;
    Password = password;
    Users.Add(this);
  }
  public static List<User> registeredUser = new List<User>();
  public static User Registration()
  {
    Console.WriteLine("Enter your firstname");
    string firstName = Console.ReadLine();
    Console.WriteLine("Enter your lastname");
    string lastName = Console.ReadLine();
    Console.WriteLine("Enter your UserName");
    string userName = Console.ReadLine();
    Console.WriteLine("Enter your password");
    string passWord = Console.ReadLine();
    User registerUser = registeredUser.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName || u.UserName == userName || u.Password == passWord);
    if (registerUser == null)
    {
      User user = new User(firstName, lastName, userName, passWord);
      registeredUser.Add(user);
      Console.WriteLine("User registered successfully!");
      Console.WriteLine();
      return user;
    }
    else
    {
      Console.WriteLine("User with the username already Exists");
      return null;
    }


  }
  public static User Login()
  {
    Menu menu = new Menu();
    Console.WriteLine("Enter your Username");
    string userName = Console.ReadLine();
    Console.WriteLine("Enter your Password");
    string passWord = Console.ReadLine();
    User userLogin = registeredUser.FirstOrDefault(u => u.UserName == userName && u.Password == passWord);
    if (userLogin != null)
    {
      Console.WriteLine("Login successful!");
      User.LogggedInUser = userLogin;
      Menu.Menus();
      return userLogin;
    }
    else
    {
      Console.WriteLine("Invalid Login Credentials");
      return null;
    }

  }
  public void Name()
  {

  }
  public static void UserExam()
  {
    
    

    if(User.LogggedInUser.IsExamDone == false)
    {
            User user = User.LogggedInUser;
    ITest chemTest = new Chemistry();
    double chemScore = chemTest.Questions(user);
    ITest bioTest = new Biology();
    double bioScore = bioTest.Questions(user);
    User.LogggedInUser.ChemistryScore = chemScore;
    user.BiologyScore = bioScore;
    User.LogggedInUser.IsExamDone = true;
    
    }
    else if(User.LogggedInUser.IsExamDone == true)
    {
    Console.WriteLine("CANNOT PARTICIPATE IN EXAM SEVERAL TIMES");
    }
   

  }
  public static void CheckGrade()
  {
     if(User.LogggedInUser.IsExamDone == false)
      {
        Console.WriteLine($"{User.LogggedInUser.LastName} {User.LogggedInUser.FirstName} has not yet participated in the exam");
      }
      else
      {

    Console.WriteLine("Student grade:");
    Console.WriteLine($"Dear ,{User.LogggedInUser.FirstName} {User.LogggedInUser.LastName}");
    double total = User.LogggedInUser.ChemistryScore + User.LogggedInUser.BiologyScore;
    double possibleTotal = 10;
    double percentage = total / possibleTotal * 100;
    Console.WriteLine($"Your Current Biology score is {User.LogggedInUser.BiologyScore}");
    Console.WriteLine($"Your Current Chemistry score is {User.LogggedInUser.ChemistryScore}");
    Console.WriteLine($"Your Current Total score is {total}");
    Console.WriteLine($"Percentage grade = {percentage}");
    User.LogggedInUser.Overall = percentage;


    double grade = User.LogggedInUser.Overall;
    if (grade <= 100 && grade >= 70)
    {
      Console.WriteLine("Your grade is A");
      User.LogggedInUser.Grade = "A";
    }
    else if (grade <= 69 && grade >= 60)
    {
      Console.WriteLine("Your grade is B");
      User.LogggedInUser.Grade = "B";
    }
    else if (grade <= 59 && grade >= 50)
    {
      Console.WriteLine("Your grade is C");
      User.LogggedInUser.Grade = "C";
    }
    else if (grade <= 49 && grade >= 40)
    {
      Console.WriteLine("Your grade is D");
      User.LogggedInUser.Grade = "D";
    }
    else if (grade <= 39 && grade >= 30)
    {
      Console.WriteLine("Your grade is E");
      User.LogggedInUser.Grade = "E";
    }
    else
    {
      Console.WriteLine("Your grade is F");
      User.LogggedInUser.Grade = "F";
    }
    }
  }
  public static void ViewScoreRankings()
  {
    Console.WriteLine();
    Console.WriteLine("Student's LeaderBoard");
    Console.WriteLine();
      var sortedScore = from studentz in registeredUser
                        orderby studentz.Grade,studentz.Overall descending,studentz.FirstName,studentz.LastName
                        select studentz;
                        
    foreach(var student in sortedScore)
    {
     
      Console.WriteLine($" {student.FirstName} {student.LastName} percentage is {student.Overall} and grade is {student.Grade}");
      
    }
  }




}