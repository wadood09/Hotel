using Food_Application_Project.Entity;
using Food_Application_Project.Manager.Implementation;
using Food_Application_Project.Manager.Interface;
using Food_Application_Project.Repository.Implementation;
using Food_Application_Project.Repository.Interface;

public class OrderingManager : IOrderingManager
{
    IOrderingRepository orderingRepo = new OrderingRepository();
    IWalletManager walletManager = new WalletManager();
    IFoodManager foodManager = new FoodManager();
    public List<Ordering> GetAllOrder()
    {
        return orderingRepo.GetAll();
    }

    public Ordering GetOrdering(string refNo)
    {
        var exist = orderingRepo.Get(a => a.RefNo == refNo);
        if (exist == null)
        {
            return null;
        }
        return exist;
    }

    public Ordering MakeOrder(int choice, int quantity, string customerWallet, string refNo, double totalPrice, DateTime createdAt)
    {
        var customer = walletManager.GetWallet(customerWallet);
        var manager = walletManager.GetWallet("MYK8023297064");
        var food = foodManager.GetAll()[choice];
        if (customer == null)
        {
            return null;
        }
        else if (manager == null)
        {
            return null;
        }
        else
        {
            if (customer.Amount >= totalPrice)
            {
                customer.Amount -= totalPrice;
                manager.Amount += totalPrice;
                Ordering ordering = new Ordering(customerWallet, totalPrice, refNo, food.FoodName, quantity);
                orderingRepo.MakeOrder(ordering);
                return ordering;
            }
            else
            {
                return null;
            }
        }
    }
    public void UpdateList()
    {
        orderingRepo.ReadAllFromFile();
    }
}