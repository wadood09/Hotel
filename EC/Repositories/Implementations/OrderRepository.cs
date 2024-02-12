using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Models.Enums;
using EC.Repositories.Interfaces;

namespace EC.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        public void Drop(Order order)
        {
            throw new NotImplementedException();
        }

        public Order Get(string refNumber)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetSelected(OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public void ReadAllFromFile()
        {
            throw new NotImplementedException();
        }

        public void RefreshFile()
        {
            throw new NotImplementedException();
        }
    }
}