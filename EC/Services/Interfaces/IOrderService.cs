using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Services.Interfaces
{
    public interface IOrderService
    {
        Order MakeOrder(Dictionary<string, int> products, string userEmail);
    }
}