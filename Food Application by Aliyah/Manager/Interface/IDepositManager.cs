using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Application_Project.Entity;

namespace Food_Application_Project.Manager.Interface
{
    public interface IDepositManager
    {
        public Deposit DepositMoney(string walletAccountNumber,double amount);
        public Deposit Get(string refNo);
        public List<Deposit> GetAll();
        void UpdateList();
    }
}