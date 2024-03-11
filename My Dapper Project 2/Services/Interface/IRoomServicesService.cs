
using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IRoomServicesService
    {
        void CreateRoomService(int hotelId, string name, double price);
        RoomService? Get(Func<RoomService, bool> pred);
        List<RoomService> GetSelected(Func<RoomService, bool> pred);
        void Delete(RoomService service);
        bool IsExist(string name, int hotelId);
        RoomService? IsExist(int num, int hotelId);
        void Update(RoomService roomService);
    }
}