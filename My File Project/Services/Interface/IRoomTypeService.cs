using My_File_Project.Models.Entities;

namespace My_File_Project.Services.Interface
{
    public interface IRoomTypeService
    {
        public void CreateRoomType(string hotelId, string name, int amountOfRooms, double price, List<string> roomNumbers);
        RoomType? Get(Func<RoomType, bool> pred);
        List<RoomType> GetSelected(Func<RoomType, bool> pred);
        bool IsDeleted(RoomType type);
        bool IsExist(string roomType, string hotelId);
        RoomType? IsExist(int number, string hotelId);
        void UpdateFile();
    }
}