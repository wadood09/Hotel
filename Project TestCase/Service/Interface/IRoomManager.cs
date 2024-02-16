using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Service.Interface
{
    public interface IRoomManager
    {
        bool IsExist(string roomNumber, int roomTypeId);
        Room GetRoom(int roomTypeId);
    }
}