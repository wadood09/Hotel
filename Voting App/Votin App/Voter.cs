using System;
using System.Collections.Generic;
namespace Votin_App
{
    public class Voter
    {
        public string Name {get;set;}

        public DateTime DateOfBirth {get;set;}
        public Gender Gender {get;set;}
        public int Age {get;} 
        public static List<Voter> Voters =  new List<Voter>();

        public Voter (string name, Gender gender, DateTime dateOfBirth)
        {
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            //Age = CalculateAge(dateOfBirth);
            Voters.Add(this);
        }
        public List<Voter> GetAllVoters()
        {
            return Voters;
        }
        // public int CalculateAge(DateTime dateOfBirth)
        // {
        //     return DateTime.Now.Year - dateOfBirth.Now.Year;
        // }
        public static Voter Register()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter gender");
            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine($"Press {(int)(item)} for {item}");
            }
            int gender = int.Parse(Console.ReadLine());
            Console.WriteLine ("Enter the dob");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            return new Voter(name,(Gender)gender, dob);
        }
        public static void Vote ()
        {
            foreach (var item in Post.Posts)
            {
                Console.WriteLine($"Press {item.Id} for {item.Name}");
            }
            int post = int.Parse(Console.ReadLine());
            var candidate = new Candidate();
            foreach (var item in candidate.GetCandidatesByPost(post))
            {
                Console.WriteLine($"Press {item.Id} for {item.NameOfCandidate} {item.Party}");

            }
            int choice = int.Parse(Console.ReadLine());
            candidate.IncreaseVoteCount(choice);

        }
        public static void Result ()
        {
            foreach (var item in Post.Posts)
            {
                Console.WriteLine($"Press {item.Id} for {item.Name}");
            }
            int post = int.Parse(Console.ReadLine());
            var candidate = new Candidate();
            int maxCount = int.MinValue;
            string winner = "";
            foreach (var item in candidate.GetCandidatesByPost(post))
            {
                Console.WriteLine($"Result  for {item.NameOfCandidate} {item.Party} is {item.VoteCount}");
                if(item.VoteCount > maxCount)
                {
                    maxCount = item.VoteCount;
                    winner = item.NameOfCandidate;
                }
            }
            Console.WriteLine($"The overall winner is {winner} with vote of {maxCount}");
            
        }

    }
}