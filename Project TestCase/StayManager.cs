class StayManager : IManager<StayHistory>
{
    static List<StayHistory> Histories = new();
    public StayHistory Add(StayHistory history)
    {
        Histories.Add(history);
        return history;
    }

    public void DeleteDetails(StayHistory value)
    {
        Histories.Remove(value);
    }

    public StayHistory Get(int id)
    {
        foreach (var history in Histories)
        {
            if(history.CustomerID == id)
            {
                return history;
            }
        }
        return null;
    }

    public List<StayHistory> GetList(int id)
    {
        List<StayHistory> histories = new List<StayHistory>();
        foreach (StayHistory history in Histories)
        {
            if(history.CustomerID == id)
            {
                histories.Add(history);
            }
        }
        return histories;
    }

    public bool IsExist(string email)
    {
        throw new NotImplementedException();
    }

    public bool Login(string email, string password)
    {
        throw new NotImplementedException();
    }
}