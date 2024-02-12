using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Repositories.Interfaces;

namespace EC.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public void Drop(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void ReadAllFromFile()
        {
            throw new NotImplementedException();
        }

        public void RefreshFile()
        {
            throw new NotImplementedException();
        }
    }
}