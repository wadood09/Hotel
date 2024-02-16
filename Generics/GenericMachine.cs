using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericMachine<T> where T : IBills
    {

        public void Withdraw()
        {

        }
        public void Deposit()
        {

        }
    }
}