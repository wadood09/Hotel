using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Service.Interface
{
    public interface IHotelManager
    {
        void Register(Hotel hotel);
        void DisplayHotels(int adminId);
        bool IsExist(string name);
        bool IsOwner(Hotel hotel, int adminId);
    }
}