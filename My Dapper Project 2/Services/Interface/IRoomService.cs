
using My_Dapper_Project_2.Entities;
using My_Dapper_Project_2.Models.Entities;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IRoomService
    {
        Room? BookRoom(DatePeriod period, int roomTypeId);
        void CreateRoom(int roomTypeId, string roomNumber);
        Room? Get(Func<Room, bool> pred);
        List<Room> GetSelected(Func<Room, bool> pred);
        bool IsDeleted(Room room);
        bool IsExist(string roomNumber, int roomTypeId);
        void Update(Room room);
    }
}