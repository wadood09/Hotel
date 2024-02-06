public class TransactionHistory : Base
{
    public string Title {get;set;}
    public string Description {get;set;}
    public int CustomerID;
    public static int HistoryCount = 0;
    public TransactionHistory(string title, string description, int customerID)
    {
        Id = HistoryCount + 1;
        Title = title;
        Description = description;
        CustomerID = customerID;
        CreatedAt = DateTime.Now;
        HistoryCount++;
    }
}