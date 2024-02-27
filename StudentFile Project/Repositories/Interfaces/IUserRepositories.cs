using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;

namespace StudentFile_Project.Repositories.Interfaces
{
    public interface IUserRepositories
    {
        public void Drop(User user);
        public User GetbyEmail(string email);
        public List<User> GetAll();
        public void ReadAllFromFile();
        public void RefreshFile();
        public void Remove(string email);
    }
}