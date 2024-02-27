using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface IRoomServicesService
    {
        void CreateRoomService(RoomServiceRequestModel model);
        RoomServiceResponseModel? Get(Func<RoomService, bool> pred);
        List<RoomServiceResponseModel> GetSelected(Func<RoomService, bool> pred);
        void Delete(RoomService service);
        bool IsExist(string name, string? hotelId);
        RoomServiceResponseModel? IsExist(int num, string hotelId);
        void Update();
    }
}