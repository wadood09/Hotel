using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_Project.Models.Entities;

namespace My_Dapper_Project.Services.Interface
{
    public interface IHotelService
    {
        Hotel? CreateHotel(string name, bool hasRoomService, double checkOutFee, List<string> roomTypes, List<double> roomPrices, List<int> roomAmount, List<List<string>> roomNumbers, List<string> roomService, List<double> servicePrices);
        Hotel? Get(Func<Hotel, bool> pred);
        List<Hotel> GetAll();
        List<Hotel> GetSelected(Func<Hotel, bool> pred);
        bool IsDeleted(Hotel hotel);
        bool IsExist(string name);
        Hotel? IsExist(int pos);
        void UpdateFile();
        void UpdateList();
    }
}