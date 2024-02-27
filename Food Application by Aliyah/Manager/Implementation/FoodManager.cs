using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

public class FoodManager : IFoodManager
{
    IFoodRepository foodRepo = new FoodRepository();
    public Food CreateFood(string foodName, double price, string foodType)
    {
        if (IsExist(foodName, foodType)) return null;
        var food = new Food(foodName, foodType, price);
        foodRepo.CreateFood(food);
        return food;

    }

    private bool IsExist(string foodName, string foodType)
    {
        var types = GetAll().Where(food => food.FoodType.ToUpper() == foodType.ToUpper());
        if (!types.Any()) return false;
        else
        {
            var isExist = types.Any(food => food.FoodName.ToUpper() == foodName.ToUpper());
            return isExist;
        }

    }

    public bool DeleteFood(int id)
    {
        var exist = foodRepo.Delete(id);
        if (exist == false)
        {
            return false;
        }
        return true;
    }

    public Food Get(string foodName)
    {
        var exist = foodRepo.Get(a => a.FoodName == foodName);
        if (exist == null)
        {
            return null;
        }
        return exist;
    }

    public List<Food> GetAll()
    {
        return foodRepo.GetAll();
    }
    public void UpdateList()
    {
        foodRepo.ReadAllFromFile();
    }
}