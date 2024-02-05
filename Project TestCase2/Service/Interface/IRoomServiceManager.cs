namespace Project_TestCase2.Service.Interface
{
    public interface IRoomServiceManager
    {
        bool IsExist(string name, int hotelId);
        void DisplayRoomServices(int hotelId);
    }
}