using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;
using Food_Application_Project.Entity;


namespace Food_Application_Project.Manager.Implementation

{
    public class UserManager : IUserManager
    {
        private User? loggedInUser = null;
        IUserRepository userRepo = new UserRepository();
        IWalletManager walletManager = new WalletManager();


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

        public void CheckAndAddSuperAdmin()
        {
            User admin = new User("Mayokun", "Bello", "08023297064", "Abk", "mayokun@gmail.com", "mayor123", "SuperAdmin");

            var userExist = GetUser(admin.Email);
            if (userExist is null)
            {
                userRepo.Create(admin);
                Wallet adminWallet = new Wallet(admin.Email, admin.PhoneNumber);
                walletManager.AddWallet(adminWallet);
            }
        }

        public User Create(string firstName, string lastName, string phoneNumber, string address, string email, string passWord, string role)
        {
            User newUser = null;
            if (!Check(email))
            {
                newUser = new User(firstName, lastName, phoneNumber, address, email, passWord, role);
                userRepo.Create(newUser);
                Wallet newUserWallet = new Wallet(newUser.Email, newUser.PhoneNumber);
                walletManager.AddWallet(newUserWallet);
            }
            return newUser;
        }

        public List<User> GetAll()
        {
            return userRepo.GetAll();
        }

        public User Get(Func<User, bool> pred)
        {
            return userRepo.Get(pred);
        }

        public User GetUser(string email)
        {
            User userExist = null;
            foreach (var item in FileContext.users)
            {
                if (item.Email.Equals(email))
                {
                    userExist = item;
                }
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
        public void UpdateList()
        {
            userRepo.ReadAllFromFile();
        }
    }
}