using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_Project.Models.Entities;

namespace My_Dapper_Project.Services.Interface
{
    public interface IRoomServicesService
    {
        void CreateRoomService(string hotelId, string name, double price);
        RoomService? Get(Func<RoomService, bool> pred);
        List<RoomService> GetSelected(Func<RoomService, bool> pred);
        void Delete(RoomService service);
        bool IsExist(string name, string? hotelId);
        RoomService? IsExist(int num, string hotelId);
        void UpdateFile();
        void UpdateList();
    }
}