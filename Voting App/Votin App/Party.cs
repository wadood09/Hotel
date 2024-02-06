using System;
using System.Collections.Generic;
namespace Votin_App
{
    public class Party
    {
      public string Name {get;set;}
        public static List<Party> Parties =  new List<Party>();
        public Party(string name)
        {
            Name = name;
            Parties.Add(this);
        }

        private static bool CheckIfNameExist(string name)
        {
            foreach (var party in Parties)
            {
                if(party.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Party> GetAllParties ()
        {
            return Parties;
        }
        public static Party Register()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            if(CheckIfNameExist(name))
            {
                Console.WriteLine("Invalid Input");
            } 
            else
            {
                return new Party(name);
            }
            return null;
        }

    }
}