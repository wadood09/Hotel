using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;

namespace My_File_Project.Services.Interface
{
    public interface IHotelService
    {
        Hotel? CreateHotel(string name, bool hasRoomService, double checkOutFee, List<string> roomTypes, List<double> roomPrices,List<int> roomAmount, List<List<string>> roomNumbers, List<string> roomService, List<double> servicePrices);
    }
}