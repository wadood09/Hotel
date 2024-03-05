using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface IHotelService
    {
        HotelResponseModel? CreateHotel(HotelRequestModel hotel);
        HotelResponseModel? Get(Func<Hotel, bool> pred);
        Hotel? Get(Func<Hotel, bool> pred, string serv);
        List<HotelResponseModel> GetAll();
        List<Hotel> GetAll(string serv);
        List<HotelResponseModel> GetSelected(Func<Hotel, bool> pred);
        List<Hotel> GetSelected(Func<Hotel, bool> pred, string serv);
        bool IsDeleted(Hotel hotel);
        bool IsExist(string name);
        HotelResponseModel? IsExist(int pos);
        void Update();
    }
}