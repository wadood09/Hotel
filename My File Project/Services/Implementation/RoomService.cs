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
    public class RoomService : IRoomService
    {
        IRepository<Room> repository = new RoomRepository();
        public void CreateRoom(string hotelId, string roomTypeId, string number)
        {
            Room room = new()
            {
                HotelId = hotelId,
                RoomTypeId = roomTypeId,
                Number = number,
            };
            repository.Add(room);
        }
    }
}