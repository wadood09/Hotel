using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        void Drop(Category category);
        void RefreshFile();
        void ReadAllFromFile();
        Category Get(string name);
        List<Category> GetAll();
    }
}