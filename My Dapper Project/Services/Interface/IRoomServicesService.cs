
using My_Dapper_Project.Models.Entities;

namespace My_Dapper_Project.Services.Interface
{
    public interface IRoomServicesService
    {
        void CreateRoomService(int typeId, string name, double price);
        RoomService? Get(Func<RoomService, bool> pred);
        List<RoomService> GetSelected(Func<RoomService, bool> pred);
        void Delete(RoomService service);
        bool IsExist(string name, int typeId);
        RoomService? IsExist(int num, int typeId);
        void Update(RoomService roomService);
    }
}