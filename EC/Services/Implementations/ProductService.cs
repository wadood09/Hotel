using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Repositories.Implementations;
using EC.Repositories.Interfaces;
using EC.Services.Interfaces;

namespace EC.Services.Implementations
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo = new ProductRepository();
        public Product CreateProduct(string name, string category, int quantity, double price)
        {
            var exists = _productRepo.Get(name);
            if(exists is not null)
            {
                exists.Quantity += quantity;
                return exists;
            }

            var product = new Product()
            {
                Name = name,
                CategoryName = category,
                Quantity = quantity,
                Price = price,
            };

            _productRepo.Drop(product);

            return product;
        }
    }
}