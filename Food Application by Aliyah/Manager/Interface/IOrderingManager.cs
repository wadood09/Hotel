using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;


namespace Food_Application_Project.Manager.Interface
{
    public interface IOrderingManager
    {
        public Ordering MakeOrder(string foodName, double quantity, string customerWallet, string managerwallet, double totalPrice,DateTime createdAt);
        public Ordering GetOrdering(string refNo);
        public List<Ordering> GetAllOrder();
    }
    
}