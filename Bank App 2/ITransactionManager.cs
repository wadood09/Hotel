public interface ITransactionManager
{
    public void Add(TransactionHistory history);
    public List<TransactionHistory> GetbyCustomerId(int customerId);
}