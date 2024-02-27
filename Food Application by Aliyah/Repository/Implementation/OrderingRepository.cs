using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Repository.Interface;

namespace Food_Application_Project.Repository.Implementation
{
    public class OrderingRepository : IOrderingRepository
    {
        public OrderingRepository()
        {
            ReadAllFromFile();
        }
        FileContext context = new FileContext();
        public Ordering Get(Func<Ordering, bool> pred)
        {
            return FileContext.orderings.SingleOrDefault(pred);
        }

        public List<Ordering> GetAll()
        {
            return FileContext.orderings;
        }

        public Ordering MakeOrder(Ordering ordering)
        {
            FileContext.orderings.Add(ordering);

            using (var str = new StreamWriter(context.Ordering))
            {
                str.WriteLine(ordering.ToString());
            }
            return ordering;
        }

        public void ReadAllFromFile()
        {
            try
            {
                var fileExist = File.Exists(context.Ordering);
                if(fileExist)
                {
                    var ordering = File.ReadAllLines(context.Ordering);
                    foreach (var item in ordering)
                    {
                        FileContext.orderings.Add(Ordering.ToOrder(item));
                    }  
                }
                else
                {
                    File.Create(context.Ordering);
                }
            }
            catch(System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return;
            
        }

        public void RefreshFile()
        {
            using(var str = new StreamWriter(context.Ordering, false))
            {
                foreach (var item in FileContext.orderings)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }
    }
}