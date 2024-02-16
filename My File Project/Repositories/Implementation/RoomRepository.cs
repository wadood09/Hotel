using System.Text.Json;
using My_File_Project.Context;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class RoomRepository : IRepository<Room>
    {
        public void Add(Room room)
        {
            HotelContext.Rooms.Add(room);

            using (StreamWriter writer = new(HotelContext.RoomFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(room));
            }
        }

        public Room? Get(Func<Room, bool> pred)
        {
            Room? room = HotelContext.Rooms.SingleOrDefault(pred);
            return room;
        }

        public List<Room> GetAll()
        {
            return HotelContext.Rooms;
        }

        public List<Room> GetSelected(Func<Room, bool> pred)
        {
            return HotelContext.Rooms.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.RoomFile, false))
            {
                foreach (Room room in HotelContext.Rooms)
                {
                    writer.WriteLine(JsonSerializer.Serialize(room));
                }
            }
        }

        public void RefreshList()
        {
            string[] rooms = File.ReadAllLines(HotelContext.RoomFile);
            foreach (string room in rooms)
            {
                HotelContext.Rooms.Add(JsonSerializer.Deserialize<Room>(room)!);
            }
        }
    }
}