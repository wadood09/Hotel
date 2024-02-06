using System;
using System.Collections.Generic;
namespace Votin_App
{
    public class Candidate
    {
        public string NameOfCandidate {get;set;}
        public int Id {get;}
        public string Party {get;set;}

        public int Post {get;set;}

        public string StateOfOrigin {get;set;}

        public int VoteCount {get; private set;}

        public static List<Candidate> Candidates =  new List<Candidate>();

        public Candidate (string name, string party, int post, string stateOfOrigin)
        {
            Id = Candidates.Count == 0 ? 1 : Candidates.Count + 1;
            NameOfCandidate = name;
            Party = party;
            Post = post;
            StateOfOrigin = stateOfOrigin;
            Candidates.Add(this);
        }
        public Candidate()
        {

        }

        public List<Candidate> GetCandidatesByPost(int post)
        {
            List<Candidate> CandidatesList = new List<Candidate>();
            foreach (var candidate in Candidates)
            {
                if(candidate.Post == post)
                {
                    CandidatesList.Add(candidate);
                }
            }
            return CandidatesList;
        }
        public List<Candidate> GetCandidates()
        {
            return Candidates;
        }
        public static Candidate Register()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the post");
            int post = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the party");
            string partyName = Console.ReadLine();
            Console.WriteLine("Enter your state of origin");
            string stateOfOrigin = Console.ReadLine();
            bool isValid = true;
            foreach (var candidate in Candidates)
            {
                if(candidate.NameOfCandidate == name)
                {
                    isValid = false;
                    break;
                }
            }
            // for (int i = 0; i < Party.Parties.Count; i++)
            // {
            //     if(Party.Parties[i].Name == partyName)
            //     {
            //         break;
            //     }
            //     if(i == Party.Parties.Count -1)
            //     {
            //         isValid = false;

            //     }
            // }
            if(!isValid)
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                return new Candidate(name,partyName,post,stateOfOrigin);
            }
            return null;
            
        }
        public void IncreaseVoteCount(int id)
        {
            foreach (var item in Candidates)
            {
                if(item.Id == id)
                {
                    item.VoteCount++;
                    break;
                }
            }
        }

    }
    
}