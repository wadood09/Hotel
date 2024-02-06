public class Candidate
{
    
    public string Name {get;set;}
    
    public string Party {get;set;}
    
    public string Post {get;set;}
    
    public string StateOfOrigin {get;set;}
    
    public int VoteCount {get;}
    public static List<Candidate> candidates = new();
    public Candidate(string name,string party,string post,string stateOfOrigin)
    {
        Name = name;
        Party = party;
        Post = post;
        StateOfOrigin = stateOfOrigin;
    }
     
}