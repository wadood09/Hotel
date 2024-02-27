using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

public class FoodManager : IFoodManager
{
    IFoodRepository foodRepo = new FoodRepository();
    public FoodManager()
    {
        foodRepo.ReadAllFromFile();
    }
    
    public Food CreateFood(string foodName,double price,string foodType)
    {
        var exist =  CreateFood(foodName,price,foodType);
        if (exist == null)
        {
            return null;
        }
        return exist;

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
}