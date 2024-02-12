using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Services.Interfaces
{
    public interface ICategoryService
    {
        Category CreateCategory(string name, string description);
        
    }
}