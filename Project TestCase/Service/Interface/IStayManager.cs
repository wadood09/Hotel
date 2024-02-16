using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Service.Interface
{
    public interface IStayManager
    {
        void DisplayRooms(List<StayHistory> histories);
        void DisplayHotels(List<StayHistory> histories);
    }
}