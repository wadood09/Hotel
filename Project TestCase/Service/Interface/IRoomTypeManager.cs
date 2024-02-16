namespace Project_TestCase2.Service.Interface
{
    public interface IRoomTypeManager
    {
        bool IsExist(string name, int hotelId);
        void DisplayRoomTypes(int hotelId);
    }
}