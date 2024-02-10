using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Service.Implementation
{
    public class RoomManager : IRoomManager
    {
        IRoomRepository Repository = new RoomRepository();

        public void DisplayRoomNumbers(int roomTypeId)
        {
            Console.WriteLine("Viewing Room number(s): ");
            foreach (Room room in Repository.GetByRoomTypeId(roomTypeId))
            {
                Console.WriteLine(room.Number);
            }
        }

        public Room GetRoom(int roomTypeId)
        {
            foreach (Room room in Repository.GetByRoomTypeId(roomTypeId))
            {
                if(room.RoomStatus == Models.Enums.RoomStatus.Vacant)
                {
                    return room;
                }
            }
            return null;
        }

        public bool IsExist(string roomNumber, int roomTypeId)
        {
            if(Repository.GetByRoomNumber(roomNumber, roomTypeId) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}