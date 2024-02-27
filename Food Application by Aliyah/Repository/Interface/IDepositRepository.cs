using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;

namespace Food_Application_Project.Repository.Interface
{
    public interface IDepositRepository
    {
        public Deposit DepositMoney(Deposit deposit);
        public List<Deposit> GetAll();
        public Deposit Get(Func<Deposit, bool> pred);
        void ReadAllFromFile();
        void RefreshFile();
    }
}