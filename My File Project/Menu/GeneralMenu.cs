using My_File_Project.Models.Entities;
using My_File_Project.Models.Enums;
using My_File_Project.Models.Extensions;
using My_File_Project.Services.Implementation;
using My_File_Project.Services.Interface;

namespace My_File_Project.Menu
{
    public class GeneralMenu
    {
        IBookingService _bookingService = new BookingService();
        IHotelService _hotelService = new HotelService();
        IRoomService _roomService = new RoomServices();
        IRoomServicesService _roomServicesService = new RoomServicesService();
        IRoomTypeService _roomTypeService = new RoomTypeService();
        IUserService _userService = new UserService();

        public void DisplayRoomTypes(string hotelId)
        {
            int count = 0;
            Console.WriteLine("Displaying all room types: ");
            List<RoomType> types = _roomTypeService.GetSelected(type => type.HotelId == hotelId);
            foreach (RoomType type in types)
            {
                Console.WriteLine($"{++count}. {type.Name!.ToPascalCase()}");
            }
        }

        public void DisplayRoomNumbers(string roomTypeId)
        {
            Console.WriteLine("Displaying Room number(s): ");
            List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == roomTypeId);
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.Number!.PadRight(10) + $" Status: {room.RoomStatus}");
            }
        }

        public void DisplayRoomServices(string hotelId)
        {
            Console.WriteLine("Displaying Room Service(s): ");
            int count = 0;
            List<RoomService> services = _roomServicesService.GetSelected(service => service.HotelId == hotelId);
            foreach (var service in services)
            {
                Console.WriteLine($"{++count}. {service.Name,-20} N{service.Price:n}");
            }
        }

        public void EnterChoice(ref int choice)
        {
            choice = -1;
            while (choice < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = Math.Abs(num);
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
        }

        public void EnterChoice(ref double choice)
        {
            choice = -1;
            while (choice < 0)
            {
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    choice = Math.Abs(num);
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
        }

        public void EnterChoice(ref char choice)
        {
            choice = '0';
            while (!"YN".Contains(choice))
            {
                if (char.TryParse(Console.ReadLine()!.ToUpper(), out char num))
                {
                    choice = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
                if(!"YN".Contains(choice))
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
        }

        public void EnterChoice(ref string? choice)
        {
            choice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(choice))
            {
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                    choice = Console.ReadLine();
                }

            }
        }

        public void CheckHotelStatus()
        {
            List<Hotel> hotels = _hotelService.GetAll();
            foreach (Hotel hotel in hotels)
            {
                CheckRoomTypeStatus(hotel.Id);
                List<RoomType> types = _roomTypeService.GetSelected(type => type.HotelId == hotel.Id);
                foreach (RoomType type in types)
                {
                    if (type.Status == Status.Active)
                    {
                        hotel.HotelStatus = Status.Active;
                        break;
                    }
                }
                hotel.HotelStatus = Status.Inactive;
            }
        }
        public void CheckRoomTypeStatus(string hotelId)
        {
            List<RoomType> types = _roomTypeService.GetSelected(type => type.HotelId == hotelId);
            foreach (RoomType type in types)
            {
                CheckRoomStatus(type.Id);
                List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == type.Id);
                foreach (Room room in rooms)
                {
                    if (room.RoomStatus == Models.Enums.RoomStatus.Occupied || room.RoomStatus == Models.Enums.RoomStatus.Booked)
                    {
                        type.Status = Status.Active;
                        break;
                    }
                    type.Status = Status.Inactive;
                }
            }
        }

        public void CheckRoomServiceStatus(ref Hotel hotel)
        {
            string hotelId = hotel.Id;
            List<RoomService> services = _roomServicesService.GetSelected(service => service.HotelId == hotelId);
            if (!services.Any())
            {
                hotel.HasRoomService = false;
            }
        }

        public void CustomerStatus()
        {
            List<Booking> bookings = _bookingService.GetSelected(booking => booking.CustomerID == Customer.LoggedInCustomerId);
            foreach (Booking booking in bookings)
            {
                if (booking.StayPeriod.WithInRange(DateTime.Now))
                {
                    booking.CustomerStatus = Status.Active;
                }
                else if (DateTime.Now > booking.StayPeriod.End)
                {
                    booking.CustomerStatus = Status.Inactive;
                }
                else
                {
                    booking.CustomerStatus = Status.Passive;
                }
            }
        }

        public void CheckRoomStatus(string roomTypeId)
        {
            List<Booking> bookings = _bookingService.GetSelected(booking => booking.RoomTypeId == roomTypeId);
            foreach (Booking booking in bookings)
            {
                Room room = _roomService.Get(room => room.Id == booking.RoomId)!;

                if (booking.CustomerStatus == Status.Active)
                    room.RoomStatus = Models.Enums.RoomStatus.Occupied;

                else if (booking.CustomerStatus == Status.Passive)
                    room.RoomStatus = Models.Enums.RoomStatus.Booked;

                else
                    room.RoomStatus = Models.Enums.RoomStatus.Vacant;
            }
        }

        public void CheckBalance(string role)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == role)!;
            Console.WriteLine($"Your wallet balance is N{user.Wallet:n}");
        }
    }
}