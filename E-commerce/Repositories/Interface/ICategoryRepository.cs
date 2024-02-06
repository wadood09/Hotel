using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models.Entities;

namespace E_commerce.Repositories.Interface
{
    public interface ICategoryRepository
    {
        void Drop(Category category);
    }
}