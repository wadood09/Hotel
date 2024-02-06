using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Models.Entities;

namespace E_commerce.Context
{
    public class FileContext
    {
        public string CategoryFile = @"C:\Users\WADOOD\OneDrive\Desktop\E-commerce\Files\Categories.txt";
        public string CustomerFile = @"C:\Users\WADOOD\OneDrive\Desktop\E-commerce\Files\Customers.txt";
        public string ManagerFile = @"C:\Users\WADOOD\OneDrive\Desktop\E-commerce\Files\Managers.txt";
        public string OrderFile = @"C:\Users\WADOOD\OneDrive\Desktop\E-commerce\Files\Orders.txt";
        public string ProductFile = @"C:\Users\WADOOD\OneDrive\Desktop\E-commerce\Files\Products.txt";
        public string UserFile = @"C:\Users\WADOOD\OneDrive\Desktop\E-commerce\Files\Users.txt";

        public static List<Category> Categories = new();
        public static List<Customer> Customers = new();
        public static List<Manager> Managers = new();
        public static List<Order> Orders = new();
        public static List<Product> Products = new();
        public static List<User> Users = new();
    }
}