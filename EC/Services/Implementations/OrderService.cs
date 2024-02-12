using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Models.Enums;
using EC.Repositories.Implementations;
using EC.Repositories.Interfaces;
using EC.Services.Interfaces;

namespace EC.Services.Implementations
{
    public class OrderService : IOrderService
    {
        IProductRepository _productRepo = new ProductRepository();
        ICustomerRepository _custRepo = new CustomerRepository();
        IUserRepository _userRepo = new UserRepository();
        IOrderRepository _orderRepo = new OrderRepository();
        public Order MakeOrder(Dictionary<string, int> products, string userEmail)
        {
            double totalPrice =  0;

            foreach (var item in products)
            {
                var prod = _productRepo.Get(item.Key);
                prod.Quantity -= item.Value;
                var price = prod.Price * item.Value;
                totalPrice += price;
            }

            var user = _userRepo.Get(userEmail);
            if(totalPrice > user.Wallet)
            {
                return null;
            }
            user.Wallet -= totalPrice;

            var order = new Order()
            {
                CustomerTagNumber = userEmail,
                Products = products,
                RefNumber = $"CLH/ORD/{new Random().Next(111,999)}",
                Status = OrderStatus.Initiadted,
                TotalPrice = totalPrice,

            };

            _orderRepo.Drop(order);
            return order;

        }
    }
}