using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models.Entities
{
    public class Product : Auditable
    {
        public string Name {get; set;}
        public string CategoryName {get; set;}
        public int Quantity {get; set;}
        public double Price {get; set;}

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{CategoryName}\t{Quantity}\t{Price}\t{IsDeleted}";
        }

        public Product ToProduct(string str)
        {
            string[] properties = str.Split('\t');
            return new Product()
            {
                Id = properties[0],
                Name = properties[1],
                CategoryName = properties[2],
                Quantity = int.Parse(properties[3]),
                Price = double.Parse(properties[4]),
                IsDeleted = bool.Parse(properties[5])
            };
        }
    }
}