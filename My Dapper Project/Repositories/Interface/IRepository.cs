using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Dapper_Project.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        void Update(T value);
        IEnumerable<T> GetAll();
    }
}