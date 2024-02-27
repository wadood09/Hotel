public class Base
{
    public int Id{get;set;} = 0;
    public DateTime CreatedAt {get;set;}


    public Base()
    {
        CreatedAt = DateTime.UtcNow;
    }

}