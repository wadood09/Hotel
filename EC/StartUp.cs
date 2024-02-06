using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC
{
    public class StartUp
    {
        public void OnStart()
        {
            var path = @"C:\Users\User\Desktop\EC\Files";
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);

            var category = Path.Combine(path,"Categories.txt");
            if(!File.Exists(category)) File.Create(category);
        }
    }
}