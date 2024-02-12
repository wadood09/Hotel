using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Drop(Product product);
        void RefreshFile();
        void ReadAllFromFile();
        Product Get(string name);
        List<Product> GetAll();
    }
}