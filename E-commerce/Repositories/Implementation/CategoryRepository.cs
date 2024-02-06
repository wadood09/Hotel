using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models.Entities;
using E_commerce.Repositories.Interface;

namespace E_commerce.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Drop(Category category)
        {
            string str = category.ToString();
        }
    }
}