
public class TransactionManager : ITransactionManager
{
    List<TransactionHistory> Histories = new List<TransactionHistory>();
    public void Add(TransactionHistory history)
    {
        Histories.Add(history);
    }

    public List<TransactionHistory> GetbyCustomerId(int customerId)
    {
        List<TransactionHistory> customerHistory = new List<TransactionHistory>();
        foreach (var history in Histories)
        {
            if(history.CustomerID == customerId)
            {
                customerHistory.Add(history);
            }
        }
        return customerHistory;
    }
}