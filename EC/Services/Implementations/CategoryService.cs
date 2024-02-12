using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Context;
using EC.Models.Entities;
using EC.Repositories.Implementations;
using EC.Repositories.Interfaces;
using EC.Services.Interfaces;

namespace EC.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepo = new CategoryRepository();
        public Category CreateCategory(string name, string description)
        {
            var exists = _categoryRepo.Get(name);
            if(exists != null)
            {
                return null;
            }

            var category = new Category()
            {
                Name = name,
                Description = description
            };

            _categoryRepo.Drop(category);

            return category;
        }
    }
}