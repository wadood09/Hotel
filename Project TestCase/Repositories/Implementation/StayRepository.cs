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

        public List<StayHistory> Get(int id)
        {
            List<StayHistory> histories = new();
            foreach (StayHistory history in HotelContext.StayHistories)
            {
                if (history.CustomerID == id)
                {
                    histories.Add(history);
                }
            }
            return histories;
        }

        public List<StayHistory> GetHotels(int customerId)
        {
            List<StayHistory> histories = new();
            List<StayHistory> store = Get(customerId).OrderBy(b => b.HotelId).ToList();
            if (store.Count == 0)
            {
                return histories;
            }
            HashSet<int> hotelIds = new();
            foreach (StayHistory history in store)
            {
                hotelIds.Add(history.HotelId);
            }
            List<int> hold = hotelIds.ToList();
            for (int i = 0; i < hotelIds.Count; i++)
            {
                foreach (StayHistory history in store)
                {
                    if (hold[i] == history.HotelId)
                    {
                        histories.Add(history);
                        break;
                    }
                }
            }
            return histories;
        }
        public List<StayHistory> GetAllHotels(int customerId, int hotelId)
        {
            List<StayHistory> histories = new();
            foreach (StayHistory history in HotelContext.StayHistories)
            {
                if(history.CustomerID == customerId && history.HotelId == hotelId)
                {
                    histories.Add(history);
                }
            }
            return histories;
        }

        public void Remove(StayHistory history)
        {
            HotelContext.StayHistories.Remove(history);
        }
    }
}