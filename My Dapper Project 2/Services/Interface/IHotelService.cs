
using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IHotelService
    {
        Hotel? CreateHotel(string name, List<string> roomTypes, List<double> roomPrices, List<int> roomAmount, List<List<string>> roomNumbers, List<string> roomService, List<double> servicePrices);
        Hotel? Get(Func<Hotel, bool> pred);
        List<Hotel> GetAll();
        List<Hotel> GetSelected(Func<Hotel, bool> pred);
        bool IsDeleted(Hotel hotel);
        bool IsExist(string name);
        Hotel? IsExist(int pos);
        void Update(Hotel hotel);
    }
}