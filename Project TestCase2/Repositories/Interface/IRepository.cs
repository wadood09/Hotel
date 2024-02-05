namespace Project_TestCase2.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        T GetById(int id);
        T GetByName(string name);
        List<T> GetList(int id);
        List<T> GetAll();

    }
}