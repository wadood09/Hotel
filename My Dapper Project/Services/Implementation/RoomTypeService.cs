using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Models.Enums;
using My_Dapper_Project.Repositories.Implementation;
using My_Dapper_Project.Repositories.Interface;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Services.Implementation
{
    public class RoomTypeService : IRoomTypeService
    {
        IRepository<RoomType> repository = new RoomTypeRepository();
        IRoomService roomService = new RoomServices();

        public void CreateRoomType(int hotelId, string name, int amountOfRooms, double price, List<string> roomNumbers)
        {
            var type = new RoomType
            {
                HotelId = hotelId,
                Name = name,
                AmountOfRooms = amountOfRooms,
                Price = price
            };

            for (int i = 0; i < roomNumbers.Count; i++)
            {
                roomService.CreateRoom(type.Id, roomNumbers[i]);
            }
            repository.Add(type);
        }

        public RoomType? Get(Func<RoomType, bool> pred)
        {
            return repository.GetAll().SingleOrDefault(pred);
        }

        public List<RoomType> GetSelected(Func<RoomType, bool> pred)
        {
            return repository.GetAll().Where(pred).ToList();
        }

        public bool IsDeleted(RoomType type)
        {
            if (type.Status == Status.Active) return false;
            List<Room> rooms = roomService.GetSelected(room => room.RoomTypeId == type.Id);
            foreach (Room room in rooms)
            {
                bool isDeleted = roomService.IsDeleted(room);
                if (!isDeleted) return false;
            }
            repository.Remove(type);
            return true;
        }

        public bool IsExist(string roomType, int hotelId)
        {
            bool isExist = Get(type => type.Name!.ToUpper() == roomType.ToUpper() && type.HotelId == hotelId) is not null;
            return isExist;
        }

        public RoomType? IsExist(int number, int hotelId)
        {
            List<RoomType> types = GetSelected(type => type.HotelId == hotelId);
            if (number > types.Count || number == 0) return null;
            else return types[--number];
        }

        public void Update(RoomType roomType)
        {
            repository.Update(roomType);
        }
    }
}