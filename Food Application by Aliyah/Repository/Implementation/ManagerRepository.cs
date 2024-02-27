using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Repository.Implementation
{
    public class ManagerRepository : IManagerRepository
    {
        public ManagerRepository()
    {
        ReadAllFromFile();
    }
    FileContext context = new FileContext();
    
    public User CreateManager(User user)
        {
            if(user != null)
            {
                FileContext.users.Add(user);
                using (var str = new StreamWriter(context.User,true))
                {
                    str.WriteLine(user.ToString());
                }
            }
            return user;
        }
        public User Get(Func<User, bool> pred)
        {
            return FileContext.users.SingleOrDefault(pred);
        }

        public List<User> GetAll()
        {
            return FileContext.users;
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
            catch(System.IO.IOException ex)
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
            using(var str = new StreamWriter(context.User, false))
            {
                foreach (var item in FileContext.users)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }

        public User UpdateManagerRole(User user, string update)
        {
            var manager = FileContext.users.FirstOrDefault(a => a.Email == user.Email);
              if(manager is not null)
              {
                  manager.URole = update;
              }
            return manager;
        }
    }
}