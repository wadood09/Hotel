using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Manager.Implementation

{
    public class UserManager : IUserManager
    {
        private User? loggedInUser = null;
        IUserRepository userRepo = new UserRepository();


        public bool Check(string email)
        {
            foreach (var user in FileContext.users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public User CreateUser(string firstName,string lastName,string phoneNumber,string address, string email, string passWord)
        {
            User newUser = null;
            if (!Check(email))
            {
                newUser = new User(firstName, lastName,phoneNumber,address,email,passWord);
                userRepo.Create(newUser);
            }
            return newUser;
        }

        public List<User> GetAll()
        {
            return userRepo.GetAll();
        }

        public User GetUser(string email)
        {
            User userExist = null;
            foreach(var item in FileContext.users)
            {
                if(item.Email.Equals(email))
                {
                    userExist = item;
                }
            }
            if (userExist == null)
            {
                return null;
            }
            return userExist;
        }

        public User Login(string email, string passWord)
        {
            User useR = null;
            foreach (var user in FileContext.users)
            {
                if (user.Email == email && user.PassWord == passWord)
                {
                    useR = user;
                    loggedInUser = useR;
                }
            }
            return useR;
        }

        public User GetLoggedINUser(User user)
        {
            return loggedInUser;
        }

        public User CreateManager(string firstName, string lastName, string phoneNumber, string address, string email, string passWord, string role)
        {
            var useR = new User(firstName,lastName,phoneNumber,address,email,passWord,role);
            var manager = userRepo.CreateManager(useR);
            return manager;

        }
    }
}