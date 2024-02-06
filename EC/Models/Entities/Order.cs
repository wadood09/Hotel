using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Models.Entities
{
    public class Order : Auditables
    {
        public string RefNumber{get; set;}
        public string CustomerTagNumber{get; set;}
        public double TotalPrice{get; set;}
        public Dictionary<string, int> Products{get; set;}

        // public override string ToString()
        // {
        //     var prd = "";
        //     foreach (var item in Products)
        //     {
        //         prd += $"{item.Key}:{item.Value},";
        //     }
        //     return $"{Id}\t{RefNumber}\t{CustomerTagNumber}\t{TotalPrice}\t{prd}";
        // }

        public override string ToString()
        {
            StringBuilder prds = new StringBuilder();
            foreach (var item in Products)
            {
                prds.Append($"{item.Key}:{item.Value},");
            }
            return $"{Id}\t{RefNumber}\t{CustomerTagNumber}\t{TotalPrice}\t{prds}\t{IsDeleted}";
        }

        public Order ToOrder(string str)
        {
            var model = str.Split('\t');
            Dictionary<string, int> products = new Dictionary<string, int>();
            var asd = model[4].Split(',');
            for(int i = 0; i < asd.Length-1; i++)
            {
                var abc = asd[i].Split(':');
                products.Add(abc[0], int.Parse(abc[1]));
            }

            return new Order()
            {
                Id = model[0],
                RefNumber = model[1],
                CustomerTagNumber = model[2],
                TotalPrice = double.Parse(model[3]),
                Products = products,
                IsDeleted = bool.Parse(model[5])
            };
        }
    }
}