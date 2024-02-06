using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Enums;

namespace BankApp.Models.Entities
{
    public class Account : BaseEntity
    {
        public string Number;
        public string AccountTypeName;
        public double Balance;
        public string CustomerBvn;
        public AccountStatus Status;

        public Account(int sN, string number, string accountTypeName, double balance, string customerBvn, AccountStatus status) : base(sN)
        {
            Number = number;
            AccountTypeName = accountTypeName;
            Balance = balance;
            CustomerBvn = customerBvn;
            Status = status;
        }
    }
}