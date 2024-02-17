using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_File_Project.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        void RefreshFile();
        void RefreshList();
        T? Get(Func<T, bool> pred);
        List<T> GetSelected(Func<T, bool> pred);
        List<T> GetAll();
    }
}