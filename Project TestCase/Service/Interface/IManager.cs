namespace Project_TestCase2.Service.Interface
{
    public interface IManager<T>
    {
        void Register(T value);
        bool Login(string email, string password);
        bool IsExist(string email);
    }
}