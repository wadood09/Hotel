using My_Dapper_Project.Entities;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Models.Enums;
using My_Dapper_Project.Repositories.Implementation;
using My_Dapper_Project.Repositories.Interface;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Services.Implementation
{
    public class RoomServices : IRoomService
    {
        IRepository<Room> repository = new RoomRepository();
        IBookingService bookingService = new BookingService();

        public Room? BookRoom(DatePeriod period, int roomTypeId)
        {
            List<Room> rooms = GetSelected(room => room.RoomTypeId == roomTypeId);
            foreach (Room room in rooms)
            {
                List<Booking> bookings = bookingService.GetSelected(booking => booking.RoomId == room.Id);

                bool isAvailable = bookings.Select(booking => new DatePeriod(booking.CheckInDate, booking.CheckOutDate)).
                All(stayPeriod => !stayPeriod.Intersects(period));

                // If the room is available, return it
                if (isAvailable)
                {
                    return room;
                }
            }
            return null;
        }

        public void CreateRoom(int roomTypeId, string roomNumber)
        {
            var room = new Room
            {
                RoomTypeId = roomTypeId,
                RoomNumber = roomNumber,
            };
            repository.Add(room);
        }

        public Room? Get(Func<Room, bool> pred)
        {
            return repository.GetAll().SingleOrDefault(pred);
        }

        public List<Room> GetSelected(Func<Room, bool> pred)
        {
            return repository.GetAll().Where(pred).ToList();
        }

        public bool IsDeleted(Room room)
        {
            if (room.RoomStatus != RoomStatus.Vacant) return false;
            repository.Remove(room);
            return true;
        }

        public bool IsExist(string roomNumber, int roomTypeId)
        {
            bool isExist = Get(room => room.RoomNumber == roomNumber && room.RoomTypeId == roomTypeId) is not null;
            return isExist;
        }

        public void Update(Room room)
        {
            repository.Update(room);
        }
    }
}