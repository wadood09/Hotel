using System;
using System.Collections.Generic;
namespace Votin_App
{
    public class Post
    {
        public int Id {get;}
      public string Name {get;set;}
      public string PartyNameOfCurrentOfficeHolder {get;}
      public string CurrentOfficeHolderName {get;}
        public static List<Post> Posts =  new List<Post>();

        public Post(string name)
        {
            Id = Posts.Count == 0 ? 1 : Posts.Count + 1;
            Name = name;
            Posts.Add(this);
        }
        public List<Post> GetAllPosts()
        {
            return Posts;
        }
        public static Post Register()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            return new Post(name);
        }

    }
}