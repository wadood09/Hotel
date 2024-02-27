// using System.Collections.Concurrent;
// using System.ComponentModel;
// using System.Data.Common;
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
    List<Ordering> orderings = new List<Ordering>();
    public OrderingManager()
    {
        orderingRepo.ReadAllFromFile();
    }

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

    public Ordering MakeOrder(string foodName, double quantity, string customerWallet, string managerwallet, double totalPrice, DateTime createdAt)
    {
        var customer = walletManager.GetWallet(customerWallet);
        var manager = walletManager.GetWallet(managerwallet);
        var food = foodManager.Get(foodName);
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
            Console.WriteLine(customer.Amount);
            Console.WriteLine(totalPrice);

            if (customer.Amount >= totalPrice)
            {
                if (food.FoodName == foodName)
                {
                    customer.Amount -= totalPrice;
                    manager.Amount += totalPrice;
                    Ordering ordering = new Ordering();
                    orderings.Add(ordering);
                    Console.WriteLine("Payment Successfull !!!");
                    return ordering;
                }
                else
                {
                    Console.WriteLine("The portion of food chosen is more than the existing portion");
                }
            }
            else
            {
                Console.WriteLine("Insufficient wallet Balance");
            }
        }
        return null;
    }
}