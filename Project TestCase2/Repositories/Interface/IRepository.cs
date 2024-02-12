namespace Project_TestCase2.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        T GetById(int id);
        List<T> GetAll();

    }
}