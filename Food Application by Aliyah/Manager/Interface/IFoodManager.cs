// using Food_Application_Project.Entity;
using Food_Application_Project.Entity;

namespace Food_Application_Project.Manager.Interface
{
    public interface IFoodManager
    {
        public Food CreateFood(string foodName,double price,string foodType);
        public Food Get(string foodName);
        public List<Food> GetAll();
        public bool DeleteFood(int id);
        void UpdateList();
    }
}