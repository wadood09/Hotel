using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface IRoomTypeService
    {
        public void CreateRoomType(RoomTypeRequestModel model);
        RoomTypeResponseModel? Get(Func<RoomType, bool> pred);
        RoomType? Get(Func<RoomType, bool> pred, string serv);
        List<RoomTypeResponseModel> GetSelected(Func<RoomType, bool> pred);
        List<RoomType> GetSelected(Func<RoomType, bool> pred, string serv);
        bool IsDeleted(RoomType type);
        bool IsExist(string roomType, string hotelId);
        RoomTypeResponseModel? IsExist(int number, string hotelId);
        void Update();
    }
}