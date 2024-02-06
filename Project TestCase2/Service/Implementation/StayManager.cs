using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Models.Extensions;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class StayManager : IStayManager
    {
        public void DisplayHotels(List<StayHistory> histories)
        {
            int count = 0;
            foreach (StayHistory history in histories)
            {
                Console.WriteLine($"{++count}. {history.Hotel.ToPascalCase()}");
            }
        }

        public void DisplayRooms(List<StayHistory> histories)
        {
            int count = 0;
            foreach (StayHistory history in histories)
            {
                Console.WriteLine($"{++count}. {history.RoomType.ToPascalCase()} {history.RoomNumber}");
            }
        }
    }
}