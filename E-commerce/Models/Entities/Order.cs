using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models.Entities
{
    public class Order : Auditable
    {
        public string RefNumber {get; set;}
        public string CustomerTagNumber {get; set;}
        public double TotalPrice {get; set;}
        public Dictionary<string, int> Products {get; set;}

        public override string ToString()
        {
            StringBuilder products = new();
            foreach (KeyValuePair<string, int> item in Products)
            {
                products.Append($"{item.Key}:{item.Value},");
            }
            return $"{Id}\t{RefNumber}\t{CustomerTagNumber}\t{TotalPrice}\t{products}\t{IsDeleted}";
        }

        public Order ToOrder(string str)
        {
            string[] properties = str.Split('\t');
            string[] products = properties[4].Split(',');
            Dictionary<string, int> product = new();
            for (int i = 0; i < products.Length; i++)
            {
                string[] holder = products[i].Split(':');
                product.Add(holder[0], int.Parse(holder[1]));
            }
            return new Order()
            {
                Id = properties[0],
                RefNumber = properties[1],
                CustomerTagNumber = properties[2],
                TotalPrice = double.Parse(properties[3]),
                Products = product,
                IsDeleted = bool.Parse(properties[5])
            };
        }
    }
}