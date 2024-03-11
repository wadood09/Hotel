
using My_Dapper_Project.Models.Entities;

namespace My_Dapper_Project.Services.Interface
{
    public interface IUserService
    {
        User? CreateUser(string firstName, string lastName, DateTime dob, string email, string password, string role);
        User? Get(Func<User, bool> pred);
        List<User> GetSelected(Func<User, bool> pred);
        void Delete(User user);
        User? Login(string email, string password);
        void Update(User user);
    }
}