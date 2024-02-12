using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EC.Context;
using EC.Models.Entities;
using EC.Repositories.Interfaces;

namespace EC.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository()
        {
            ReadAllFromFile();
        }
        FileContext context = new FileContext();
        public void Drop(Category category)
        {

            FileContext.Categories.Add(category);

            using(var str = new StreamWriter(context.CategoryFile, true))
            {
                var b = JsonSerializer.Serialize(category);
                str.WriteLine(b);
            }
        }

        public Category Get(string name)
        {
            var category = FileContext.Categories.SingleOrDefault(a => a.Name == name);
            return category;
        }

        public List<Category> GetAll()
        {
            return FileContext.Categories;
        }

        public void ReadAllFromFile()
        {
            var categories = File.ReadAllLines(context.CategoryFile);
            foreach (var item in categories)
            {
                FileContext.Categories.Add(Category.ToCategory(item));
            }
        }

        public void RefreshFile()
        {
            using(var str = new StreamWriter(context.CategoryFile, false))
            {
                foreach (var item in FileContext.Categories)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }

        
    }
}