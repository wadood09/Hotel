using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC.Models.Entities
{
    public class Category : Auditables
    {
        public string Name{get; set;}
        public string Description{get; set;}

        // public string ConvertToString(Category category)
        // {
        //     return $"{category.Id}\t{category.Name}\t{category.Description}\t{category.IsDeleted}";
        // }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Description}\t{IsDeleted}";
        }

        public static Category ToCategory(string str)
        {
            var model = str.Split('\t');
            return new Category
            {
                Id = model[0],
                Name = model[1],
                Description = model[2],
                IsDeleted = bool.Parse(model[3])
            };
        }
    }
}