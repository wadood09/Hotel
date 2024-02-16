using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class RoomTypeService : IRoomTypeService
    {
        IRepository<RoomType> repository = new RoomTypeRepository();
        public void CreateRoomType(string hotelId, string name, int amountOfRooms, double price)
        {
            RoomType type = new()
            {
                HotelId = hotelId,
                Name = name,
                AmountOfRooms = amountOfRooms,
                Price = price
            };
            repository.Add(type);
        }
    }
}