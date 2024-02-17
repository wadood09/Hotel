using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using My_File_Project.Context;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class RoomServiceRepository : IRepository<RoomService>
    {
        public void Add(RoomService roomService)
        {
            HotelContext.RoomServices.Add(roomService);

            using (StreamWriter writer = new(HotelContext.RoomServiceFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(roomService));
            }
        }

        public RoomService? Get(Func<RoomService, bool> pred)
        {
            RoomService? roomService = HotelContext.RoomServices.SingleOrDefault(pred);
            return roomService;
        }

        public List<RoomService> GetAll()
        {
            return HotelContext.RoomServices;
        }

        public List<RoomService> GetSelected(Func<RoomService, bool> pred)
        {
            return HotelContext.RoomServices.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.RoomServiceFile, false))
            {
                foreach (RoomService roomService in HotelContext.RoomServices)
                {
                    writer.WriteLine(JsonSerializer.Serialize(roomService));
                }
            }
        }

        public void RefreshList()
        {
            string[] roomServices = File.ReadAllLines(HotelContext.RoomServiceFile);
            foreach (string roomService in roomServices)
            {
                HotelContext.RoomServices.Add(JsonSerializer.Deserialize<RoomService>(roomService)!);
            }
        }

        public void Remove(RoomService roomService)
        {
            HotelContext.RoomServices.Remove(roomService);

            RefreshFile();
        }
    }
}