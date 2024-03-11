using My_Dapper_Project.Models.Entities;

namespace My_Dapper_Project.Services.Interface
{
    public interface IRoomTypeService
    {
        public void CreateRoomType(int hotelId, string name, int amountOfRooms, double price, List<string> roomNumbers);
        RoomType? Get(Func<RoomType, bool> pred);
        List<RoomType> GetSelected(Func<RoomType, bool> pred);
        bool IsDeleted(RoomType type);
        bool IsExist(string roomType, int hotelId);
        RoomType? IsExist(int number, int hotelId);
        void Update(RoomType roomType);
    }
}