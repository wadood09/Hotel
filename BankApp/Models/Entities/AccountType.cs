using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Entities
{
    public class AccountType : BaseEntity
    {
        public string Name;
        public double OpeningBalance;
        public double MinimumBalance;
        public double TransferLimit;

        public AccountType(int sN, string name, double openingBalance, double minimumBalance, double transferLimit) : base(sN)
        {
            Name = name;
            OpeningBalance = openingBalance;
            MinimumBalance = minimumBalance;
            TransferLimit = transferLimit;
        }
    }
}