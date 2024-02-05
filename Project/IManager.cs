interface IManager<T>
{
    public bool IsExist(string email);
    public T Add(T admin);
    public bool Login(string email, string password);
    public T Get(int id);
    public void DeleteDetails(T value);
}