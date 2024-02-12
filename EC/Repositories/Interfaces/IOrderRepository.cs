using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;
using EC.Models.Enums;

namespace EC.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Drop(Order order);
        void RefreshFile();
        void ReadAllFromFile();
        Order Get(string refNumber);
        List<Order> GetSelected(OrderStatus status);
        List<Order> GetAll();
    }
}