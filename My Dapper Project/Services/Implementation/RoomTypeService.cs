using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void CreateRoomType(string hotelId, string name, int amountOfRooms, double price, List<string> roomNumbers)
        {
            RoomType type = new()
            {
                HotelId = hotelId,
                Name = name,
                AmountOfRooms = amountOfRooms,
                Price = price
            };

            for (int i = 0; i < roomNumbers.Count; i++)
            {
                roomService.CreateRoom(type.HotelId, type.Id, roomNumbers[i]);
            }
            repository.Add(type);
        }

        public RoomType? Get(Func<RoomType, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<RoomType> GetSelected(Func<RoomType, bool> pred)
        {
            return repository.GetSelected(pred);
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

        public bool IsExist(string roomType, string hotelId)
        {
            bool isExist = repository.Get(type => type.Name!.ToUpper() == roomType.ToUpper() && type.HotelId == hotelId) is not null;
            return isExist;
        }

        public RoomType? IsExist(int number, string hotelId)
        {
            List<RoomType> types = repository.GetSelected(type => type.HotelId == hotelId);
            if (number > types.Count || number == 0) return null;
            else return types[--number];
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }

        public void UpdateList()
        {
            repository.RefreshList();
        }
    }
}