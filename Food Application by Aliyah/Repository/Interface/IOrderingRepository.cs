using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Application_Project.Repository.Interface
{
    public interface IOrderingRepository
    {
        public Ordering MakeOrder(Ordering ordering);
        public Ordering Get(Func<Ordering, bool> pred);
        public List<Ordering> GetAll();
        void ReadAllFromFile();
        void RefreshFile();
    }
}