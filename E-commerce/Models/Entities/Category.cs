using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models.Entities
{
    public class Category : Auditable
    {
        public string Name {get; set;}
        public string Description {get; set;}

        // public string ConvertToString(Category category)
        // {
        //     return $"{category.Id}\t{category.Name}\t{category.Description}\t{category.IsDeleted}";
        // }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Description}\t{IsDeleted}";
        }

        public Category ToCategory(string str)
        {
            string[] properties = str.Split('\t');
            return new Category()
            {
                Id = properties[0],
                Name = properties[1],
                Description = properties[2],
                IsDeleted = bool.Parse(properties[3])
            };
        }
    }
}