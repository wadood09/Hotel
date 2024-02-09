using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Struct___Enums
{
    public static class Extension
    {
        public static State State(this MonthsOfTheYear months)
        {
            switch ((int)months)
            {
                case 30:
                    return Struct___Enums.State.IsRegular;
                case 31:
                    return Struct___Enums.State.IsIrregular;
                default:
                    return Struct___Enums.State.IsAbnormal;
            }
        }
    }
}