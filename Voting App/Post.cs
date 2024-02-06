public class Post
{
    public string Name { get; set; }

    public string PartyNameOfCurrentOfficer { get; set; }

    public string NameOfCurrentOfficer { get; set; }
    public static List<Post> posts = new();
}