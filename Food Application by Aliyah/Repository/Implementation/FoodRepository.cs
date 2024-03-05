using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Repository.Implementation
{
    public class FoodRepository : IFoodRepository
    {
        FileContext context = new FileContext();
        public Food CreateFood(Food food)
        {
            FileContext.foods.Add(food);

            using (var str = new StreamWriter(context.Food, true))
            {
                str.WriteLine(food.ToString());
            }
            return null;
        }

        public bool Delete(int id)
        {
            var delete = FileContext.foods.SingleOrDefault(a => a.Id == id);
            return false;
        }

        public Food Get(Func<Food, bool> pred)
        {
            return FileContext.foods.SingleOrDefault(pred);
        }

        public List<Food> GetAll()
        {
            return FileContext.foods;
        }

        public void ReadAllFromFile()
        {
            try
            {
                var food = File.ReadAllLines(context.Food);
                foreach (var item in food)
                {
                    FileContext.foods.Add(Food.ToFood(item));
                }
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;

        }

        public void Refreshfile()
        {
            using (var str = new StreamWriter(context.Food, false))
            {
                foreach (var item in FileContext.foods)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }
    }
}