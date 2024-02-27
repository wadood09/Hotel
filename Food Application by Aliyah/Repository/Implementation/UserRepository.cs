using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        FileContext context = new FileContext();
        IWalletRepository walet = new WalletRepository();
        public UserRepository()
        {
            ReadAllFromFile();
            CheckAndAddSuperAdmin();
        }

        public void CheckAndAddSuperAdmin()
        {
            User admin = new User("Mayokun", "Bello", "08023297064", "Abk", "mayokun@gmail.com", "mayor123")
            {
                URole = "SuperAdmin"
            };
            
            var userExist = Get(a => a.Email == admin.Email);
            if(userExist is null)
            {
                FileContext.users.Add(admin);
                Wallet adminWallet = new Wallet(admin.Email, admin.PhoneNumber);
                walet.AddWallet(adminWallet);
                using (var str = new StreamWriter(context.User,true))
                {
                   str.WriteLine(admin.ToString());
                }
            }
            
        }
        
        public User Create(User user)
        {
            FileContext.users.Add(user);

            using (var str = new StreamWriter(context.User,true))
            {
                str.WriteLine(user.ToString());
            }
            return user;
        }

        public User CreateManager(User user)
        {
            FileContext.users.Add(user);

            using (var str = new StreamWriter(context.User,true))
            {
                str.WriteLine(user.ToString());
            }
            return user;
        }

        

        public User Get(Func<User, bool> pred)
        {
            return FileContext.users.FirstOrDefault(pred);
        }

        public List<User> GetAll()
        {
            return FileContext.users;
        }

        public User Login(string email, string passWord)
        {
            var user = FileContext.users.SingleOrDefault(a => a.Email == email && a.PassWord == passWord);
            return user;
        }

        public void ReadAllFromFile()
        {
            try
            {
                var fileExist = File.Exists(context.User);
                if(fileExist)
                {
                    var user = File.ReadAllLines(context.User);
                    foreach (var item in user)
                    {
                        FileContext.users.Add(User.ToUser(item));
                    }  
                }
                else
                {
                    File.Create(context.User);
                } 
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;
                 
        }

        public void RefreshFile()
        {
            // File.WriteAllText(context.User, string.Empty);
            using(var str = new StreamWriter(context.User, false))
            {
                foreach (var item in FileContext.users)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }
    }
}