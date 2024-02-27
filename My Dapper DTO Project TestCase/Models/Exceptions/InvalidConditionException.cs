using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Dapper_DTO_Project_TestCase.Models.Exceptions
{
    public class InvalidConditionException : Exception
    {
        public override string Message => "All or some of the required conditions have not yet been met!!!";
    }
}