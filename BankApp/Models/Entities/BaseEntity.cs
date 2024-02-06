using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Entities
{
    public class BaseEntity
    {
        public int SN;

        public BaseEntity(int sN)
        {
            SN = sN;
        }
    }
}