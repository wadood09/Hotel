using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EC.Menu;

namespace EC
{
    public class StartUp
    {
        public void OnStart()
        {
            var path = @"\Files";
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);

            var category = Path.Combine(path,"Categories.txt");
            if(!File.Exists(category)) File.Create(category);

            var customer = Path.Combine(path,"Customers.txt");
            if(!File.Exists(customer)) File.Create(customer);

            var manager = Path.Combine(path,"Managers.txt");
            if(!File.Exists(manager)) File.Create(manager);

            var order = Path.Combine(path,"Orders.txt");
            if(!File.Exists(order)) File.Create(order);

            var product = Path.Combine(path,"Products.txt");
            if(!File.Exists(product)) File.Create(product);

            var user = Path.Combine(path,"Users.txt");
            if(!File.Exists(user)) File.Create(user);

            Main m = new Main();
            m.MainMenu();
        }
    }
}