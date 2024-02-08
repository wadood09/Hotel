namespace Project_TestCase2.Service.Interface
{
    public interface IRoomServiceManager
    {
        bool IsExist(string name, int hotelId);
        bool IsExist(int num, int hotelId);
        void DisplayRoomServices(int hotelId);
        void DisplayNames(int hotelId);
    }
}