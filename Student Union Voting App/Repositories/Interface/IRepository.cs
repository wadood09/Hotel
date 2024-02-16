using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Union_Voting_App.Models.Entities;

namespace Student_Union_Voting_App.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Drop (T value);
        void RefreshFile();
        void ReadAllFromFile();
        T Get(Func<T, bool> pred);
        List<T> GetSelected(Func<T, bool> pred);
        List<T> GetAll();
    }
}