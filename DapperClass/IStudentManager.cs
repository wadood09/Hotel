namespace DapperClass
{
    public interface IStudentManager
    {
        Student Create(Student std);
        IList<Student> GetAll();
        Student Get (int id);
        Student Update (Student std);
        void Delete (int id);
        void SetUp();
    }
}