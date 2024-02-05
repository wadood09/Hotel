using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class RoomManager : IRoomManager
    {
        IRoomRepository Repository = new RoomRepository();
        public bool IsExist(string roomNumber, int roomTypeId)
        {
            if(Repository.GetByRoomNumber(roomNumber, roomTypeId) != null)
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