using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Models.Entities;

namespace EC.Context
{
    public class FileContext
    {
        public string CategoryFile = @".\Files\Categories.txt";
        public string CustomerFile = @".\Files\Customers.txt";
        public string ManagerFile = @".\Files\Managers.txt";
        public string OrderFile = @".\Files\Orders.txt";
        public string ProductFile = @".\Files\Products.txt";
        public string UserFile = @".\Files\Users.txt";

        public static List<Category> Categories = new List<Category>();
        public static List<Customer> Customers = new List<Customer>();
        public static List<Manager> Managers = new List<Manager>();
        public static List<Order> Orders = new List<Order>();
        public static List<Product> Products = new List<Product>();
        public static List<User> Users = new List<User>();
        
    }
}