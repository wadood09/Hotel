// See https://aka.ms/new-console-template for more information

namespace User_Input
{
    class program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello Wadood!");
            // Console.Write("Please enter score: " + score);
            // int score = int.Parse(Console.ReadLine());
            // bool result = score >= 50;
            // bool result2 = score < 50;
            // if(result == true)
            // {
            //     Console.WriteLine("YOU PASSED!!!");
            // }
            // if(result2 == true)
            // {
            //     int finalScore = score + 10;
            //     if(finalScore >= 50)
            //     {
            //         Console.WriteLine("YOU PASSED!!!");
            //     }
            //     else
            //     {
            //         Console.WriteLine("YOU FAILED!!!");
            //     }
            // }
            

            // 2
            // Console.Write("Please enter first number: ");
            //  int firstNo = int.Parse(Console.ReadLine());
           
            // Console.Write("Please enter second number: ");
            //  int secondNo = int.Parse(Console.ReadLine());
            
            // Console.Write("Please enter third number: ");
            //  int thirdNo = int.Parse(Console.ReadLine());
            
            // Console.Write("Please enter fourth number: ");
            //  int fourthNo = int.Parse(Console.ReadLine());
            
            // Console.Write("Please enter fifth number: ");
            //  int fifthNo = int.Parse(Console.ReadLine());
             
            //  int even = 0;
            //  int odd = 0;
            //  if(firstNo % 2 == 0)
            //  {
            //     even += 1;
            //  }
            //  else
            //  {
            //     odd += 1;
            //  }
            //  if (secondNo % 2 == 0)
            //  {
            //     even += 1;
            //  }
            //  else
            //  {
            //     odd += 1;
            //  }
            //  if (thirdNo % 2 == 0)
            //  {
            //     even += 1;
            //  }
            //  else
            //  {
            //     odd += 1;
            //  }
            //  if (fourthNo % 2 == 0)
            //  {
            //     even += 1;
            //  }
            //  else
            //  {
            //     odd += 1;
            //  }
            //  if (fifthNo % 2 == 0)
            //  {
            //     even += 1;
            //  }
            //  else
            //  {
            //     odd += 1;
            //  }
            //  Console.Write("You have entered " + even + " even numbers and "
            //   + odd +" odd numbers");
            Console.Write("Hello student 1,enter your score: ");
            int firstScore = int.Parse(Console.ReadLine());
            Console.Write("Hello student 2,enter your score: ");
            int secondScore = int.Parse(Console.ReadLine());
            Console.Write("Hello student 3,enter your score: ");
            int thirdScore = int.Parse(Console.ReadLine());
            Console.Write("Hello student 4,enter your score: ");
            int fourthScore = int.Parse(Console.ReadLine());
            Console.Write("Hello student 5,enter your score: ");
            int fifthScore = int.Parse(Console.ReadLine());
            int highestScore = firstScore;
            if(firstScore < secondScore)
            {
                highestScore = secondScore;
            }
            if(secondScore < thirdScore)
            {
                highestScore = thirdScore;
            }
            if(thirdScore < fourthScore)
            {
                highestScore = fourthScore;
            }
            if(fourthScore < fifthScore)
            {
                highestScore = fifthScore;
            }
            Console.WriteLine("The highest score entered is " + highestScore);
        }
    }
}
