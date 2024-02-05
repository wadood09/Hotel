using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class StayRepository : IRepository<StayHistory>
    {
        public void Add(StayHistory history)
        {
            HotelContext.StayHistories.Add(history);
        }

        public List<StayHistory> GetAll()
        {
            return HotelContext.StayHistories;
        }

        public StayHistory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public StayHistory GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<StayHistory> GetList(int id)
        {
            List<StayHistory> histories = new();
            foreach (StayHistory history in HotelContext.StayHistories)
            {
                if(history.CustomerID == id)
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