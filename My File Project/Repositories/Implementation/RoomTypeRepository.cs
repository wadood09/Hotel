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
    public class RoomTypeRepository : IRepository<RoomType>
    {
        public void Add(RoomType roomType)
        {
            HotelContext.RoomTypes.Add(roomType);

            using (StreamWriter writer = new(HotelContext.RoomTypeFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(roomType));
            }
        }

        public RoomType? Get(Func<RoomType, bool> pred)
        {
            RoomType? roomType = HotelContext.RoomTypes.SingleOrDefault(pred);
            return roomType;
        }

        public List<RoomType> GetAll()
        {
            return HotelContext.RoomTypes;
        }

        public List<RoomType> GetSelected(Func<RoomType, bool> pred)
        {
            return HotelContext.RoomTypes.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.RoomTypeFile, false))
            {
                foreach (RoomType roomType in HotelContext.RoomTypes)
                {
                    writer.WriteLine(JsonSerializer.Serialize(roomType));
                }
            }
        }

        public void RefreshList()
        {
            string[] roomTypes = File.ReadAllLines(HotelContext.RoomTypeFile);
            foreach (string roomType in roomTypes)
            {
                HotelContext.RoomTypes.Add(JsonSerializer.Deserialize<RoomType>(roomType)!);
            }
        }
    }
}