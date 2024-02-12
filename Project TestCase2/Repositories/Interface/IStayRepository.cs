using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Repositories.Interface
{
    public interface IStayRepository
    {
        void Add(StayHistory history);
        List<StayHistory> Get(int id);
        List<StayHistory> GetAll();
        List<StayHistory> GetByRoomTypeId(int roomTypeId);
        List<StayHistory> GetHotels(int customerId);
        void Remove(StayHistory history);
        List<StayHistory> GetAllHotels(int customerId, int hotelId);
    }
}