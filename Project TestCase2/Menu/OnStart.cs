using System.Text;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Models.Extensions;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Menu
{
    public class OnStart
    {
        IRoomRepository _roomRepository = new RoomRepository();
        IRoomServiceRepository _roomServiceRepository = new RoomServiceRepository();
        IRoomTypeRepository _roomTypeRepository = new RoomTypeRepository();
        IStayRepository _historyRepository = new StayRepository();
        IHotelRepository _hotelRepository = new HotelRepository();


        public void CheckHotelStatus()
        {
            foreach (Hotel hotel in _hotelRepository.GetList(Admin.LoggedInAdminId))
            {
                foreach (RoomType type in _roomTypeRepository.GetAllByHotelId(hotel.Id))
                {
                    if (type.Status == Models.Enums.RoomTypeStatus.Active)
                    {
                        hotel.HotelStatus = Models.Enums.HotelStatus.Active;
                        break;
                    }
                }
                hotel.HotelStatus = Models.Enums.HotelStatus.Inactive;
            }
        }
        public void CheckRoomTypeStatus()
        {
            foreach (RoomType type in _roomTypeRepository.GetAll())
            {
                foreach (Room room in _roomRepository.GetByRoomTypeId(type.Id))
                {
                    if (room.RoomStatus == Models.Enums.RoomStatus.Occupied)
                    {
                        type.Status = Models.Enums.RoomTypeStatus.Active;
                        break;
                    }
                    type.Status = Models.Enums.RoomTypeStatus.Inactive;
                }
            }
        }

        public void CheckRoomServiceStatus(ref Hotel hotel)
        {
            if (_roomServiceRepository.GetByHotelId(hotel.Id).Count == 0)
            {
                hotel.RoomService = false;
            }
        }

        public void CustomerStatus()
        {
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            foreach (StayHistory history in histories)
            {
                if (DateTime.Now > history.CheckOutDate)
                {
                    history.CustomerStatus = Models.Enums.CustomerStatus.CheckedOut;
                }
            }
        }

        public void RoomStatus()
        {
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            foreach (StayHistory history in histories)
            {
                if (history.CheckInDate > DateTime.Now)
                    _roomRepository.GetByRoomNumber(history.RoomNumber, history.RoomTypeId).RoomStatus = Models.Enums.RoomStatus.Vacant;
                else
                    _roomRepository.GetByRoomNumber(history.RoomNumber, history.RoomTypeId).RoomStatus = Models.Enums.RoomStatus.Occupied;
            }
        }
        public bool IsAvailable(int id, int days, int night)
        {
            List<Room> rooms = _roomRepository.GetByRoomTypeId(id);
            int count = 0;
            DateTime checkIn = DateTime.Now.AddDays(days);
            DateTime checkOut = checkIn.AddDays(night);
            foreach (StayHistory history in _historyRepository.GetAll())
            {
                if (checkIn.WithInRange(history.CheckInDate, history.CheckOutDate) || checkOut.WithInRange(history.CheckInDate, history.CheckOutDate))
                {
                    count++;
                }
            }
            if (count < rooms.Count) return true;
            else return false;
        }
    }
}