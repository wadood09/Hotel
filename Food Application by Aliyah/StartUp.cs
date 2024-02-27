using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Application
{
    public class StartUp
    {
        string FoodApp = @"C:\Users\User\Desktop\Food Application\foodapp";
        public void Create()
        {
            if(!Directory.Exists(FoodApp)) Directory.CreateDirectory(FoodApp);

            var deposit = Path.Combine(FoodApp,"deposits.txt");
            if(!File.Exists(deposit)) File.Create(deposit);

            var food = Path.Combine(FoodApp,"foods.txt");
            if (!File.Exists(food)) File.Create(food);

            var Ordering = Path.Combine(FoodApp,"orderings.txt");
            if(!File.Exists(Ordering)) File.Create(Ordering);

            var user = Path.Combine(FoodApp,"users.txt");
            if(!File.Exists(user)) File.Create(user);

            var wallet = Path.Combine(FoodApp,"wallets.txt");
            if(!File.Exists(wallet)) File.Create(wallet);
        }
    }
}