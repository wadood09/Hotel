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
    public class RoomServicesService : IRoomServicesService
    {
        IRepository<RoomService> repository = new RoomServiceRepository();
        public void CreateRoomService(string hotelId, string name, double price)
        {
            RoomService service = new()
            {
                HotelId = hotelId,
                Name = name,
                Price = price
            };
            repository.Add(service);
        }
    }
}