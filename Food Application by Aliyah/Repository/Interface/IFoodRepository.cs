using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;

namespace Food_Application_Project.Repository.Interface
{
    public interface IFoodRepository
    {
        public Food CreateFood(Food food);
        public Food Get(Func<Food, bool> pred);
        public List<Food> GetAll();
        public bool Delete(int id);
        void ReadAllFromFile();
        void Refreshfile();
    }
}