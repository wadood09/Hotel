using My_Dapper_DTO_Project_Testcase.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;
using My_Dapper_DTO_Project_Testcase.Repositories.Implementation;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;
using My_Dapper_DTO_Project_Testcase.Services.Interface;

namespace My_Dapper_DTO_Project_Testcase.Services.Implementation
{
    public class RoomServices : IRoomService
    {
        IRepository<Room> repository = new RoomRepository();
        IRepository<Booking> bookingRepo = new BookingRepository();

        public Room? BookRoom(DatePeriod period, string roomTypeId)
        {
            List<Room> rooms = repository.GetSelected(room => room.RoomTypeId == roomTypeId);
            foreach (Room room in rooms)
            {
                List<Booking> bookings = bookingRepo.GetSelected(booking => booking.RoomId == room.Id);
                bool isAvailable = bookings.All(booking => !booking.StayPeriod.Intersects(period));

                // If the room is available, return it
                if (isAvailable)
                {
                    return room;
                }
            }
            return null;
        }

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

        public Room? Get(Func<Room, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<Room> GetSelected(Func<Room, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public bool IsDeleted(Room room)
        {
            if (room.RoomStatus != RoomStatus.Vacant) return false;
            repository.Remove(room);
            return true;
        }

        public bool IsExist(string num, string roomTypeId)
        {
            bool isExist = repository.Get(room => room.Number == num && room.RoomTypeId == roomTypeId) is not null;
            return isExist;
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