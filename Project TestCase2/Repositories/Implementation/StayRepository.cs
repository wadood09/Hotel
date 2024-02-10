using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class StayRepository : IStayRepository
    {
        public void Add(StayHistory history)
        {
            HotelContext.StayHistories.Add(history);
        }

        public List<StayHistory> Get(int customerId)
        {
            return HotelContext.StayHistories.Where(history => history.CustomerID == customerId).ToList();
        }

        public List<StayHistory> GetHotels(int customerId)
        {
            List<StayHistory> histories = new();
            var store = Get(customerId).OrderBy(b => b.HotelId);
            if (!store.Any())
            {
                return histories;
            }
            List<int> hotelIds = store.Select(history => history.HotelId).Distinct().ToList();
            for (int i = 0; i < hotelIds.Count; i++)
            {
                histories.Add(store.First(history => history.HotelId == hotelIds[i]));
            }
            return histories;
        }
        public List<StayHistory> GetAllHotels(int customerId, int hotelId)
        {
            return HotelContext.StayHistories.Where(history => history.CustomerID == customerId && history.HotelId == hotelId).ToList();
        }

        public void Remove(StayHistory history)
        {
            HotelContext.StayHistories.Remove(history);
        }
    }
}