using System.Security.Cryptography.X509Certificates;

public class Menu
{
    static void Main()
{
    bool isContinue = true;
while(isContinue)
{
Console.WriteLine("Console GradeBook Project");
Console.WriteLine();
Console.WriteLine("Press 1:Registration");
Console.WriteLine("Press 2:Login");                 
Console.WriteLine("Press 0:Exit Program");                 
int choice = int.Parse(Console.ReadLine());
switch(choice)
{
    case 1:
    User.Registration();
    break;
    case 2:
    User.Login();
    break;
    case 0:
    isContinue = false;
    Console.WriteLine("Program Closed Successfully");
    break;
    default:
    Console.WriteLine("Invalid Input");
    break;
}  
} 
  
}
    public static void Menus()
   {
   
    bool isContinue = true;
    while(isContinue)
    {
    Console.WriteLine();
    Console.WriteLine("Student's Menu");
    Console.WriteLine();
    Console.WriteLine("Press 1: Participate In Exam ");
    Console.WriteLine("Press 2: Check Grade");
    Console.WriteLine("Press 3: ViewScoreRankings ");
    Console.WriteLine("Press 0: LogOut");
    int userChoice = int.Parse(Console.ReadLine());
    switch(userChoice)
    {
        case 1:
        User.UserExam();
        break;
        case 2:
        User.CheckGrade();
        break;
        case 3:
        User.ViewScoreRankings();
        break;
        case 0:
        isContinue = false;
        Console.WriteLine("Logged out successfully");
        break;
        default:
        Console.WriteLine("Invalid input");
        break;
        
        
    }
   }
  } 
}    