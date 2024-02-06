using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Context
{
    public class FileContext
    {
        public string CategoryFile = @"C:\Users\User\Desktop\EC\Files\Categories.txt";
        public string CustomerFile = @"C:\Users\User\Desktop\EC\Files\Customers.txt";
        public string ManagerFile = @"C:\Users\User\Desktop\EC\Files\Managers.txt";
        public string OrderFile = @"C:\Users\User\Desktop\EC\Files\Orders.txt";
        public string ProductFile = @"C:\Users\User\Desktop\EC\Files\Products.txt";
        public string UserFile = @"C:\Users\User\Desktop\EC\Files\Users.txt";

        public static List<Category> Categories = new List<Category>();
        public static List<Customer> Customers = new List<Customer>();
        public static List<Manager> Managers = new List<Manager>();
        public static List<Order> Orders = new List<Order>();
        public static List<Product> Products = new List<Product>();
        
    }
}