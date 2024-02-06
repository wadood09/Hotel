using System;

namespace Votin_App
{
    class Program
    {
        static void Main(string[] args)
        {
          
            bool isContinue = true;
            while(isContinue)
            {
                 Console.WriteLine("Welcome to Voting Application");
           Console.WriteLine(@"Press 1 to register voter 
                                Press 2 to register candidate
                                Press 3 to create party
                                Press 4 to create post
                                Press 5 to vote
                                Press 6 to show resut 
                                Press 7 to exit");
               int choice =  int.Parse(Console.ReadLine());
               switch (choice)
               {
                 case 1 :
                    Voter.Register();
                 break;
                 case 2 :
                 Candidate.Register();
                 break;
                 case 3 :
                 Party.Register();
                 break;
                 case 4 :
                 Post.Register();
                 break;
                 case 5 :
                 Voter.Vote();
                 break;
                 case 6 :
                 Voter.Result();
                 break;
                 case 7 :
                 isContinue = false;
                 break;
                 default :
                 Console.WriteLine("Wrong Input");
                 break;
               }
            }

        }
    }
} 
