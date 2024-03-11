using My_Dapper_Project.Entities;
using My_Dapper_Project.Helper.Extensions;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Models.Enums;
using My_Dapper_Project.Services.Implementation;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Menu
{
    public class GeneralMenu
    {
        IBookingService _bookingService = new BookingService();
        IHotelService _hotelService = new HotelService();
        IRoomService _roomService = new RoomServices();
        IRoomServicesService _roomServicesService = new RoomServicesService();
        IRoomTypeService _roomTypeService = new RoomTypeService();
        IUserService _userService = new UserService();

        public void DisplayRoomTypes(int hotelId)
        {
            int count = 0;
            Console.WriteLine("Displaying all room types: ");
            List<RoomType> types = _roomTypeService.GetSelected(type => type.HotelId == hotelId);
            foreach (RoomType type in types)
            {
                Console.WriteLine($"{++count}. {type.Name.ToPascalCase(), -20} {type.Price}");
            }
        }

        public void DisplayRooms(int roomTypeId)
        {
            Console.WriteLine("Displaying Room (s): ");
            List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == roomTypeId);
            Console.WriteLine("ROOM NUMBERs".PadRight(10) + "STATUS");
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.RoomNumber!.PadRight(10) + $" Status: {room.RoomStatus}");
            }
        }

        public void DisplayRoomServices(int hotelId)
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
                if (!"YN".Contains(choice))
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

        public void EnterChoice(ref DateTime choice)
        {
            while (choice.Year < 1930 || choice.Year > DateTime.Today.Year)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    choice = date;
                }
                else
                {
                    Console.WriteLine("Invalid Format for Date of Birth!!!\nTry again: ");
                }
                if (choice.Year < 1930 || choice.Year > DateTime.Today.Year)
                {
                    Console.WriteLine("Invalid Date of Birth!!!\nTry Again");
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
        public void CheckRoomTypeStatus(int hotelId)
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

        public void CustomerStatus()
        {
            List<Booking> bookings = _bookingService.GetSelected(booking => booking.CustomerID == Customer.LoggedInCustomerId);
            foreach (Booking booking in bookings)
            {
                DatePeriod stayPeriod = new(booking.CheckInDate, booking.CheckOutDate);
                if (stayPeriod.WithInRange(DateTime.Now))
                {
                    booking.CustomerStatus = Status.Active;
                }
                else if (DateTime.Now > stayPeriod.End)
                {
                    booking.CustomerStatus = Status.Inactive;
                }
                else
                {
                    booking.CustomerStatus = Status.Passive;
                }
            }
        }

        public void CheckRoomStatus(int roomTypeId)
        {
            List<Booking> bookings = _bookingService.GetSelected(booking => booking.RoomTypeId == roomTypeId);
            foreach (Booking booking in bookings)
            {
                Room room = _roomService.Get(room => room.Id == booking.RoomId)!;

                if (booking.CustomerStatus == Status.Active)
                    room.RoomStatus = RoomStatus.Occupied;

                else if (booking.CustomerStatus == Status.Passive)
                    room.RoomStatus = RoomStatus.Booked;

                else
                    room.RoomStatus = RoomStatus.Vacant;
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