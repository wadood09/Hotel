using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Dapper_DTO_Project_Testcase.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        void Update(T value);
        IEnumerable<T> GetAll();
        // IEnumerable<T> GetAll();
    }
}