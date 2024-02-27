using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface IRoomService
    {
        RoomResponseModel? BookRoom(DatePeriod period, string roomTypeId);
        void CreateRoom(Room room);
        RoomResponseModel? Get(Func<Room, bool> pred);
        List<RoomResponseModel> GetSelected(Func<Room, bool> pred);
        bool IsDeleted(Room room);
        bool IsExist(string num, string roomTypeId);
        void Update();
    }
}