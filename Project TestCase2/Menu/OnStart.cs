using System.Text;
using Project_TestCase2.Models.Entities;
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
                    _roomRepository.GetByRoomNumber(history.RoomNumber, history.RoomTypeId).RoomStatus = Models.Enums.RoomStatus.Occupied;
                else
                    _roomRepository.GetByRoomNumber(history.RoomNumber, history.RoomTypeId).RoomStatus = Models.Enums.RoomStatus.Vacant;
            }
        }
        public bool IsAvailable(int id, int days, int night)
        {
            List<Room> rooms = _roomRepository.GetByRoomTypeId(id);
            // StringBuilder status = new();
            while (arriveAlice < leaveAlice || arriveBob < leaveBob)
            {
                if (arriveAlice == arriveBob)
                {
                    alice++;
                    arriveBob = arriveBob.AddDays(1);
                }
                arriveAlice = arriveAlice.AddDays(1);
            }
            var histories = _historyRepository.GetByRoomTypeId(id).Where(history => history.CheckInDate >= DateTime.Now.AddDays(days) && history.CheckOutDate <= DateTime.Now.AddDays(days + night));
            // if (!histories.Any())
            //     return true;
            if (histories.Count() < rooms.Count)
                return true;
            else
                return false;
            //     List<StayHistory> histories = new();
            //     foreach (StayHistory history in _historyRepository.GetByRoomTypeId(id))
            //     {
            //         if(history.CheckOutDate > DateTime.Now.AddDays(days))
            //         {
            //             histories.Add(history);
            //         }
            //     }
            //     if(histories.Count < rooms.Count)
            //     {
            //         return true;
            //     }
            //     else
            //     {
            //         return false;
            //     }
        }

    }
}