using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_TestCase2.Models.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool WithInRange(this DateTime value, DateTime startDate, DateTime endDate)
        {
            return (startDate <= value) && (value <= endDate);
        }
    }
}
