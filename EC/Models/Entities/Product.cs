using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.Models.Entities
{
    public class Product : Auditables
    {
        public string Name{get; set;}
        public string CategoryName{get; set;}
        public int Quantity{get; set;}
        public double Price{get; set;}

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{CategoryName}\t{Quantity}\t{Price}\t{IsDeleted}";
        }

        public Product ToProduct(string str)
        {
            var model = str.Split('\t');
            return new Product()
            {
                Id = model[0],
                Name = model[1],
                CategoryName = model[2],
                Quantity = int.Parse(model[3]),
                Price = double.Parse(model[4]),
                IsDeleted = bool.Parse(model[5])
            };
        }
    }
}