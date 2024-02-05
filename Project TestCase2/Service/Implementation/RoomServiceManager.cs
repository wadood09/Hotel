using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class RoomServiceManager : IRoomServiceManager
    {
        IRoomServiceRepository Repository = new RoomServiceRepository();

        public void DisplayRoomServices(int hotelId)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string name, int hotelId)
        {
            if(Repository.GetByName(name, hotelId) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}