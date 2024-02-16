namespace My_File_Project.Services.Interface
{
    public interface IRoomTypeService
    {
        public void CreateRoomType(string hotelId, string name, int amountOfRooms, double price);
    }
}