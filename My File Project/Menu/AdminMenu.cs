using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Models.Entities;
using My_File_Project.Services.Implementation;
using My_File_Project.Services.Interface;
using My_File_Project.Models.Extensions;
using My_File_Project.Models.Enums;

namespace My_File_Project.Menu
{
    public class AdminMenu
    {
        private bool skip = false;
        private Random random = new();
        private ConsoleColor[] colours = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow };
        IAdminService _adminService = new AdminService();
        ICustomerService _customerService = new CustomerService();
        IHotelService _hotelService = new HotelService();
        IRoomService _roomService = new RoomServices();
        IRoomServicesService _roomServicesService = new RoomServicesService();
        IRoomTypeService _roomTypeService = new RoomTypeService();
        IUserService _userService = new UserService();
        public void MainMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                if (!skip)
                {
                    User user = _userService.Get(user => user.Id == User.LoggedInUserId)!;
                    Console.WriteLine($"Welcome {user.FirstName!.ToPascalCase()} {user.LastName!.ToPascalCase()}");
                    skip = true;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== ADMIN MENU ======");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Register Hotel");
                Console.WriteLine("2. View Hotel Details");
                Console.WriteLine("3. Update Hotel Details");
                Console.WriteLine("4. Remove Hotel");
                Console.WriteLine("5. Delete Account");
                Console.WriteLine("0. Logout");
                int choice = 7;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t====== REGISTERING HOTEL ======");
                        RegisterHotel();
                        break;
                    case 2:
                        Console.WriteLine("\t====== VIEWING HOTEL DETAILS ======");
                        ViewHotelDetails();
                        break;
                    case 3:
                        UpdateHotelDetails();
                        break;
                    case 4:
                        Console.WriteLine("\t====== REMOVING HOTEL ======");
                        RemoveHotel();
                        break;
                    case 5:
                        Console.WriteLine("\t====== DELETING ACCOUNT ======");
                        DeleteAccount();
                        break;
                    case 0:
                        skip = false;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void RegisterHotel()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            string name = "";
            List<string> roomTypes = new();
            List<double> roomPrices = new();
            List<int> roomAmount = new();
            List<List<string>> roomNumbers = new();
            EnterNameAndTypes(ref name, ref roomTypes);
            if (roomTypes.Count == 0)
            {
                Console.WriteLine("Your hotel is being registered without any rooms!!!");
            }
            else
            {
                EnterRoomPrices(roomTypes, ref roomPrices);
                EnterRoomAmount(roomTypes, ref roomAmount);
                EnterRoomNumber(roomTypes, roomAmount, ref roomNumbers);
            }

            double fees = 0;
            EnterCheckOutFees(ref fees);

            bool roomService = false;
            List<string> roomServices = new();
            List<double> prices = new();
            RoomService(ref roomService, ref roomServices, ref prices);

            Hotel? hotel = _hotelService.CreateHotel(name, roomService, fees, roomTypes, roomPrices, roomAmount, roomNumbers, roomServices, prices);
            if (hotel is null)
            {
                Console.WriteLine($"Hotel with name '{name}' already exists!!!");
            }
            else
            {
                Console.WriteLine("Hotel Registration Successfull!!!");
            }
            Read();
        }

        private void EnterNameAndTypes(ref string name, ref List<string> roomTypes)
        {
            Console.Write("Enter name of hotel: ");
            bool isExist = true;
            while (isExist || string.IsNullOrWhiteSpace(name))
            {
                name = Console.ReadLine()!.ToUpper();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid Input!!!\nTry again");
                    continue;
                }
                if (_hotelService.IsExist(name))
                {
                    Console.WriteLine($"A hotel with '{name}' name already exists!!!\nTry again");
                }
                else
                {
                    isExist = false;
                }
            }
            Console.WriteLine("Enter types of rooms in hotel: ");
            string input;
            while ((input = Console.ReadLine()!) != "")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid Input!!!");
                    continue;
                }
                if (roomTypes.Contains(input))
                {
                    Console.WriteLine("Cannot have room types of the same name in a hotel!!!");
                    continue;
                }
                roomTypes.Add(input);
            }
        }

        private void EnterRoomPrices(List<string> roomTypes, ref List<double> roomPrices)
        {
            Console.WriteLine("Enter prices of rooms in hotel: ");
            foreach (string room in roomTypes)
            {
                double price = -1;
                while (price < 0)
                {
                    Console.Write($"{room.ToPascalCase()}:  ");
                    if (double.TryParse(Console.ReadLine(), out double num))
                    {
                        price = Math.Abs(num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                roomPrices.Add(price);
            }
        }

        private void EnterRoomAmount(List<string> roomTypes, ref List<int> roomAmount)
        {
            Console.WriteLine("Enter amount of rooms under: ");
            foreach (string room in roomTypes)
            {
                int amount = -1;
                while (amount < 0)
                {
                    Console.Write($"{room.ToPascalCase()}:  ");
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        amount = Math.Abs(num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                roomAmount.Add(amount);
            }
        }

        private void EnterRoomNumber(List<string> roomTypes, List<int> roomAmount, ref List<List<string>> roomNumbers)
        {
            int index = 0;
            foreach (string type in roomTypes)
            {
                List<string> roomNumber = new();
                Console.WriteLine($"Enter room number for rooms under {type.ToPascalCase()}: ");
                for (int i = 1; i <= roomAmount[index]; i++)
                {
                    string? hold = null;
                    bool isExist = true;
                    while (isExist || string.IsNullOrWhiteSpace(hold))
                    {
                        hold = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(hold))
                        {
                            Console.WriteLine("Invalid Input!!!\nTry again");
                            continue;
                        }
                        if (roomNumber.Contains(hold))
                        {
                            Console.WriteLine($"{hold} room number already exists wthin room type!!!\nTry again");
                        }
                        else
                        {
                            isExist = false;
                        }
                    }
                    roomNumber.Add(hold);
                }
                roomNumbers.Add(roomNumber);
                index++;
            }
        }

        private void EnterCheckOutFees(ref double fees)
        {
            Console.Write("Enter early check-out fee: ");
            fees = -1;
            while (fees < 0)
            {
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    fees = Math.Abs(num);
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
        }

        private void RoomService(ref bool roomService, ref List<string> roomServices, ref List<double> Prices)
        {
            char choice = new();
            Console.WriteLine("Do you want your hotel to provide room service? (Y/N)");
            EnterChoice(ref choice);
            if (choice == 'N') return;

            EnterRoomService(ref roomService, ref roomServices, ref Prices, null);
        }

        private void EnterRoomService(ref bool roomService, ref List<string> roomServices, ref List<double> Prices, string? hotelId)
        {
            Console.WriteLine("Enter types of room services you want your hotel to be providing: ");
            string input;
            while ((input = Console.ReadLine()!) != "")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid Input!!!");
                    continue;
                }
                bool isExist = _roomServicesService.IsExist(input, hotelId);
                if (roomServices.Contains(input) || isExist)
                {
                    Console.WriteLine("Cannot have room services of same name in a hotel");
                    continue;
                }
                roomServices.Add(input);
            }
            if (roomServices.Any())
            {
                Console.WriteLine("Enter price of room service(s): ");
                foreach (string service in roomServices)
                {
                    Console.Write($"{service.ToPascalCase()}:  ");
                    double price = new();
                    EnterChoice(ref price);
                    Prices.Add(price);
                }
                roomService = true;
            }
            else
            {
                Console.WriteLine("Your hotel is not providing room service");
            }
        }

        private void ViewHotelDetails()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            if (hotel.Count == 0)
            {
                Console.WriteLine("Cannot view hotel details until hotel has been registered by user!!!");
                Read();
                return;
            }
            int choice = 1;
            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;
            HotelDetails(hotel[choice]);
            Read();
        }

        private void HotelDetails(Hotel hotel)
        {
            List<RoomType> roomTypes = _roomTypeService.GetSelected(type => type.HotelId == hotel.Id);
            List<RoomService> roomServices = _roomServicesService.GetSelected(service => service.HotelId == hotel.Id);

            Console.Write("Hotel Name: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine($"\t{hotel.Name}");

            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine("ROOM TYPES".PadRight(20) + "AMOUNT OF ROOM".PadRight(30) + "PRICES OF ROOMS");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < roomTypes.Count; i++)
            {
                Console.WriteLine(roomTypes[i].Name!.ToPascalCase().PadRight(20) + roomTypes[i].AmountOfRooms.ToString().PadRight(30) + $"N{roomTypes[i].Price:n}");
            }

            if (hotel.HasRoomService)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("ROOM SERVICES".PadRight(20) + "PRICES");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (RoomService service in roomServices)
                {
                    Console.WriteLine(service.Name!.ToPascalCase().PadRight(20) + $"N{service.Price:n}");
                }
            }
        }

        private void ChooseHotel(List<Hotel> hotel, ref int choice)
        {
            if (hotel.Count > 1)
            {
                DisplayHotels(Admin.LoggedInAdminId!);
                Console.WriteLine("Choose which hotel to view details (i.e enter 1,2,3,...)");
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

                if (choice > hotel.Count || choice == 0)
                {
                    choice = -1;
                    Console.WriteLine("Hotel chosen does not exists");
                    Read();
                    return;
                }
            }
            choice--;
        }

        private void UpdateHotelDetails()
        {
            List<Hotel> hotels = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            if (hotels.Count == 0)
            {
                Console.WriteLine("Cannot update hotel details until hotel has been registered by user!!!");
                Read();
                return;
            }

            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== UPDATING HOTEL DETAILS ======");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("1. Hotel Name");
                Console.WriteLine("2. Rooms");
                Console.WriteLine("3. Room Service");
                Console.WriteLine("4. Change Early Check Out fees");
                Console.WriteLine("0. Exit");

                int choice = 5;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = Math.Abs(num);
                }

                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t====== UPDATING HOTEL NAME ======");
                        UpdateHotelName();
                        break;
                    case 2:
                        UpdateRoomTypes();
                        break;
                    case 3:
                        UpdateRoomService();
                        break;
                    case 4:
                        Console.WriteLine("\t====== CHANGING CHECK-OUT FEES ======");
                        ChangeCheckOutFees();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void UpdateHotelName()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;

            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;

            HotelName(ref hotel, choice);
            Read();
        }

        private void HotelName(ref List<Hotel> hotel, int choice)
        {
            Console.Write("Enter new hotel name: ");
            string? hotelName = null;
            while (string.IsNullOrWhiteSpace(hotelName))
            {
                hotelName = Console.ReadLine()!.ToUpper();
                if (string.IsNullOrWhiteSpace(hotelName))
                {
                    Console.WriteLine("Invalid Input!!!\nTry again");
                }
            }

            if (_hotelService.IsExist(hotelName))
            {
                Console.WriteLine($"Hotel with name '{hotelName}' already exists");
                Console.WriteLine("Update Unsuccessfull");
            }
            else
            {
                hotel[choice].Name = hotelName;
                Console.WriteLine($"You have successfully changed your hotel name to '{hotelName}'");
            }
        }

        private void UpdateRoomTypes()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== UPDATING ROOM TYPES ======");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("1. Add Room Type");
                Console.WriteLine("2. Remove Room Type");
                Console.WriteLine("3. Change price of existing Room Type");
                Console.WriteLine("4. Change amount of rooms available in Room Type");
                Console.WriteLine("5. Add Room");
                Console.WriteLine("6. Remove Room");
                Console.WriteLine("7. Change Room Number");
                Console.WriteLine("0. Exit");

                int choice = 8;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = Math.Abs(num);
                }

                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t======ADDING ROOM TYPE======");
                        AddRoomType();
                        break;
                    case 2:
                        Console.WriteLine("\t======REMOVING ROOM TYPE======");
                        RemoveRoomType();
                        break;
                    case 3:
                        Console.WriteLine("\t======CHANGING PRICE OF ROOM TYPE======");
                        ChangePriceOfRoomType();
                        break;
                    case 4:
                        Console.WriteLine("\t======CHANGING AMOUNT OF ROOM TYPE======");
                        ChangeAmountOfRoomType();
                        break;
                    case 5:
                        Console.WriteLine("\t======ADDING ROOM======");
                        AddRoom();
                        break;
                    case 6:
                        Console.WriteLine("\t======REMOVING ROOM======");
                        RemoveRoom();
                        break;
                    case 7:
                        Console.WriteLine("\t======CHANGING ROOM NUMBER======");
                        ChangeRoomNumber();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void AddRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;

            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;

            AddRoomType(hotel[choice]);
            Read();
        }

        private void AddRoomType(Hotel hotel)
        {
            string? roomType = null;
            EnterType(ref roomType, hotel.Id);
            if (roomType is null) return;

            double price = new();
            EnterPrice(ref price);

            int amount = new();
            EnterAmount(ref amount);

            List<string> roomNumbers = new();
            EnterRoomNumbers(ref roomNumbers, roomType, amount);

            _roomTypeService.CreateRoomType(hotel.Id, roomType, amount, price, roomNumbers);
            Console.WriteLine($"Room type '{roomType.ToPascalCase()}' added successfully");
        }

        private void EnterType(ref string? name, string hotelId)
        {
            Console.Write("Enter room type to add: ");
            name = Console.ReadLine()!;
            while (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid Input!!!\nTry again");
                    name = Console.ReadLine()!;
                }
            }
            if (_roomTypeService.IsExist(name, hotelId))
            {
                Console.WriteLine($"Room Type '{name.ToPascalCase()}' already exists");
                Console.WriteLine("Unable to add room type");
                Console.WriteLine("Update Unsuccessfull");
                name = null;
                return;
            }
        }

        private void EnterPrice(ref double price)
        {
            Console.Write("Enter price of room type: ");
            price = -1;
            while (price < 0)
            {
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    price = Math.Abs(num);
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
        }

        private void EnterAmount(ref int amount)
        {
            Console.Write("Enter amount of rooms under room type: ");
            amount = -1;
            while (amount < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    amount = Math.Abs(num);
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
        }

        private void EnterRoomNumbers(ref List<string> roomNumbers, string roomType, int amount)
        {
            Console.WriteLine($"Enter room numbers of rooms under type '{roomType.ToPascalCase()}'");
            for (int i = 1; i <= amount; i++)
            {
                string num = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(num))
                {
                    Console.WriteLine("Invalid Input!!!\nTry again");
                    i--;
                    continue;
                }
                if (roomNumbers.Contains(num))
                {
                    Console.WriteLine($"Room number '{num}' already exists in this room type!!!");
                    i--;
                    continue;
                }
                roomNumbers.Add(num);
            }
        }

        private void RemoveRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;
            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;
            RemoveRoomType(hotel[choice]);
            Read();
        }

        private void RemoveRoomType(Hotel hotel)
        {
            DisplayRoomTypes(hotel.Id);
            int choice = new();

            Console.Write("Choose which room type to remove (i.e enter 1,2,3,...) ");
            EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                if (type.Status == Status.Active)
                {
                    Console.WriteLine($"Cannot remove room type because it is being occupied!!!\nTry again later");
                    return;
                }

                if (_roomTypeService.IsDeleted(type))
                    Console.WriteLine($"Successfully removed room type");
                else
                    Console.WriteLine($"Cannot remove room type because it is being occupied!!!\nTry again later");
            }
            else
            {
                Console.WriteLine($"Room Type chosen does not exists!!!");
                Console.WriteLine("Unable to remove room type!!!");
                Console.WriteLine("Update Unsuccessfull!!!");
            }
        }

        private void EnterChoice(ref int choice)
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

        private void EnterChoice(ref double choice)
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

        private void EnterChoice(ref char choice)
        {
            choice = '0';
            while (choice != 'Y' || choice != 'N')
            {
                if (char.TryParse(Console.ReadLine()!.ToUpper(), out char num) && "YN".Contains(num))
                {
                    choice = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
        }

        private void ChangePriceOfRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;
            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;
            ChangePriceOfRoomType(hotel[choice]);
            Read();
        }

        private void ChangePriceOfRoomType(Hotel hotel)
        {
            DisplayRoomTypes(hotel.Id);
            Console.WriteLine("Choose which room type price to be changed (i.e enter 1,2,3,...) ");
            int choice = new();
            EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                Console.Write("Enter new price: ");
                double price = new();
                EnterChoice(ref price);

                type.Price = price;
                Console.WriteLine($"Price of room type has been successfully changed to N{price:n}");
            }
            else
            {
                Console.WriteLine($"Room Type chosen does not exists");
                Console.WriteLine("Unable to change price of unavailable room type");
                Console.WriteLine("Update Unsuccessfull");
            }
        }

        private void ChangeAmountOfRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;
            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;
            ChangeAmountOfRoomType(hotel[choice]);
            Read();
        }

        private void ChangeAmountOfRoomType(Hotel hotel)
        {
            DisplayRoomTypes(hotel.Id);
            Console.Write("Choose which room type amount to change: ");
            int choice = new();
            EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                Console.Write("Enter new amount of rooms: ");
                int amount = new();
                EnterChoice(ref amount);
                if (amount > type.AmountOfRooms)
                {
                    Console.WriteLine($"The new amount of room type {type.Name} is higher than the former amount!!!");
                    Console.WriteLine("Enter room numbers of newly added rooms: ");
                    int times = amount - type.AmountOfRooms;
                    CreateRoom(times, hotel.Id, type.Id);
                }
                else
                {
                    Console.WriteLine($"The new amount of room type {type.Name} is lower than the former amount!!!");
                    int times = type.AmountOfRooms - amount;
                    List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == type.Id && room.RoomStatus == RoomStatus.Vacant);
                    if (rooms.Count < times)
                    {
                        Console.WriteLine("The available rooms that can be removed is less than the amount of rooms to be removed!!!");
                        Console.WriteLine("Unable to change amount of rooms available!!!");
                        Console.WriteLine("Update Unsuccessfull!!!");
                        return;
                    }
                    DisplayRoomNumbers(type.Id);
                    Console.WriteLine("Enter room number of rooms to be removed");
                    RemoveRoom(times, type.Id);
                }
                type.AmountOfRooms = amount;
                Console.WriteLine($"Amount of room type has been successfully changed to {amount}");
            }
            else
            {
                Console.WriteLine($"Room Type chosen does not exists");
                Console.WriteLine("Unable to change amount of unavailable room type");
                Console.WriteLine("Update Unsuccessfull!!!");
            }
        }

        private void CreateRoom(int times, string hotelId, string roomTypeId)
        {
            for (int i = 1; i <= times; i++)
            {
                string num = Console.ReadLine()!;
                if (_roomService.IsExist(num, roomTypeId))
                {
                    Console.WriteLine($"Room number {num} alredy exists within this room type!!!\nTry Again");
                    i--;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(num))
                {
                    Console.WriteLine("Invalid Input!!!\nTry again");
                    i--;
                    continue;
                }
                _roomService.CreateRoom(hotelId, roomTypeId, num);
            }
        }

        private void RemoveRoom(int times, string roomTypeId)
        {
            for (int i = 1; i <= times; i++)
            {
                string num = Console.ReadLine()!;
                if (_roomService.IsExist(num, roomTypeId))
                {
                    Room room = _roomService.Get(room => room.RoomTypeId == roomTypeId && room.Number == num)!;
                    bool isDeleted = _roomService.IsDeleted(room);
                    if (!isDeleted)
                    {
                        Console.WriteLine("Cannot remove occupied or booked room!!!\nTry Again");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine("Room number does not exist!!!\nTry again");
                    i--;
                }
            }
        }

        private void AddRoom()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;

            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;

            AddRoom(hotel[choice]);
            Read();
        }

        private void AddRoom(Hotel hotel)
        {
            DisplayRoomTypes(hotel.Id);

            Console.Write("Under which room type is room to be added: ");
            int choice = new();
            EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                Console.Write("Enter room number of room to be added: ");
                CreateRoom(1, hotel.Id, type.Id);
                Console.WriteLine("Room added successfully!!!");
            }
            else
            {
                Console.WriteLine($"Room type chosen does not exist!!!");
            }
        }

        private void RemoveRoom()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;

            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;

            RemoveRoom(hotel[choice]);
            Read();
        }

        private void RemoveRoom(Hotel hotel)
        {
            DisplayRoomTypes(hotel.Id);
            Console.Write("Under which room type does room to be removed exists: ");
            int choice = new();
            EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == type.Id && room.RoomStatus == RoomStatus.Vacant);
                if (!rooms.Any())
                {
                    Console.WriteLine("No available room to be removed!!!\nTry again later");
                    return;
                }

                DisplayRoomNumbers(type.Id);
                Console.Write("Enter room number of room to be removed: ");
                RemoveRoom(1, type.Id);
            }
            else
            {
                Console.WriteLine($"Room type chosen does not exist!!!");
            }
        }

        private void ChangeRoomNumber()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;

            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;

            ChangeRoomNumber(hotel[choice]);
            Read();
        }

        private void ChangeRoomNumber(Hotel hotel)
        {
            DisplayRoomTypes(hotel.Id);

            Console.Write("Under which room type is room number to be changed: ");
            int choice = new();
            EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == type.Id && room.RoomStatus == RoomStatus.Vacant);
                if (!rooms.Any())
                {
                    Console.WriteLine("No available room to be changed!!!\nTry again later");
                    return;
                }

                DisplayRoomNumbers(type.Id);
                Console.Write("Enter room number of room to be changed: ");
                ChangeRoomNumber(type.Id);
            }
            else
            {
                Console.WriteLine($"Room type does not exist!!!");
            }
        }

        private void ChangeRoomNumber(string roomTypeId)
        {
            string num = Console.ReadLine()!;
            if (_roomService.IsExist(num, roomTypeId))
            {
                Console.Write("Enter new room number: ");
                string newNum = Console.ReadLine()!;
                while (string.IsNullOrWhiteSpace(newNum))
                {
                    if (string.IsNullOrWhiteSpace(newNum))
                    {
                        Console.WriteLine("Invalid Input!!!\nTry again");
                        newNum = Console.ReadLine()!;
                    }
                }
                if (!_roomService.IsExist(newNum, roomTypeId))
                {
                    Room room = _roomService.Get(room => room.RoomTypeId == roomTypeId && room.Number == num)!;
                    room.Number = newNum;
                    Console.WriteLine($"You have successfully changed room's room number to {newNum}");
                }
                else
                {
                    Console.WriteLine($"A room with {newNum} room number already exists within the same type!!!");
                    Console.WriteLine("Update Unsuccessfull!!!");
                }
            }
            else
            {
                Console.WriteLine($"Room with room number {num} does not exist!!!");
            }
        }

        private void UpdateRoomService()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== UPDATING ROOM SERVICES ======");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Add Room Service");
                Console.WriteLine("2. Remove Room Service");
                Console.WriteLine("3. Change price of existing Room Service");
                Console.WriteLine("0. Exit");
                int choice = 4;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t======ADDING ROOM SERVICE======");
                        AddRoomService();
                        break;
                    case 2:
                        Console.WriteLine("\t======REMOVING ROOM SERVICE======");
                        RemoveRoomService();
                        break;
                    case 3:
                        Console.WriteLine("\t======CHANGING PRICE OF ROOM SERVICE======");
                        ChangePriceOfRoomService();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void AddRoomService()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;

            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;

            AddRoomService(ref hotel, choice);
            Read();
        }

        private void AddRoomService(ref List<Hotel> hotel, int choice)
        {
            char input = 'Y';
            if (!hotel[choice].HasRoomService)
            {
                Console.WriteLine("Are you sure you want your hotel to be providing room service (Y/N)");
                EnterChoice(ref input);
            }
            if (input == 'Y')
            {
                List<string> roomServices = new();
                List<double> prices = new();
                bool hasRoomService = hotel[choice].HasRoomService;
                EnterRoomService(ref hasRoomService, ref roomServices, ref prices, hotel[choice].Id);

                hotel[choice].HasRoomService = hasRoomService;
                for (int i = 0; i < prices.Count; i++)
                {
                    _roomServicesService.CreateRoomService(hotel[choice].Id, roomServices[i], prices[i]);
                }
                Console.WriteLine("Room service(s) has been added successfully!!!");
            }
            else
            {
                Console.WriteLine("Your hotel is not providing room service");
                hotel[choice].HasRoomService = false;
            }
        }

        private void RemoveRoomService()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            int choice = 1;

            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;

            RemoveRoomService(ref hotel, choice);
            Read();
        }

        private void RemoveRoomService(ref List<Hotel> hotel, int choice)
        {
            if (hotel[choice].HotelStatus == Status.Active)
            {
                Console.WriteLine("Cannot remove room service because hotel status is active!!!\nTry again later");
                Read();
                return;
            }
            if (!hotel[choice].HasRoomService)
            {
                Console.WriteLine("Cannot remove room service because your hotel isn't providing room service!!!");
                Console.WriteLine("Kindly add room service in order to remove room sevice.");
                Console.WriteLine("Thank you");
            }
            else
            {
                DisplayRoomServices(hotel[choice].Id);
                Console.WriteLine("Choose which room service to be removed (i.e enter 1,2,3,...)");

                int number = new();
                EnterChoice(ref number);

                RoomService? service = _roomServicesService.IsExist(number, hotel[choice].Id);
                if (service is not null)
                {
                    _
                    Hotel hotel = hotel[choice];
                    Console.WriteLine($"Room service has been removed successfully!!!");
                }
                else
                {
                    Console.WriteLine($"The room service chosen does not exist!!!");
                }
            }
        }

        private void ChangePriceOfRoomService()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;
            ChangePriceOfRoomService(hotel, choice);
            Read();
        }

        private void ChangePriceOfRoomService(List<Hotel> hotel, int choice)
        {
            if (!hotel[choice].RoomService)
            {
                Console.WriteLine("Cannot change room service price because your hotel isn't providing room service!!!");
                Console.WriteLine("Kindly add room service in order to change room sevice price.");
                Console.WriteLine("Thank you");
            }
            else
            {
                _roomServiceManager.DisplayNames(hotel[choice].Id);
                Console.WriteLine("Choose which room service price to be changed (i.e enter 1,2,3,...)");
                int number = -1;
                while (number < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                        number = num;
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (_roomServiceManager.IsExist(number, hotel[choice].Id))
                {
                    Console.Write("Enter new price of room service: ");
                    double price = -1;
                    while (price < 0)
                    {
                        if (double.TryParse(Console.ReadLine(), out double num))
                        {
                            price = num;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!!!");
                            Console.WriteLine("Try again");
                        }
                    }
                    _roomServiceRepository.Get(number, hotel[choice].Id).Price = price;
                    Console.WriteLine($"Price of chosen room service has been successfully changed to N{price:n}");
                }
                else
                {
                    Console.WriteLine($"The room service chosen does not exist!!!");
                }
            }
        }

        private void ChangeCheckOutFees()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            ChooseHotel(hotel, ref choice);
            if (choice < 0) return;
            Console.Write("Enter new Check out fees: ");
            hotel[choice].EarlyCheckOutFee = -1;
            while (hotel[choice].EarlyCheckOutFee < 0)
            {
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    hotel[choice].EarlyCheckOutFee = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            Console.WriteLine($"Successfully changed check out fees to N{hotel[choice].EarlyCheckOutFee:n}");
            Read();
        }


        public void DisplayHotels(string adminId)
        {
            int count = 0;
            Console.WriteLine("Viewing all hotels: ");
            List<Hotel> hotels = _hotelService.GetSelected(hotel => hotel.AdminId == adminId);
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine($"{++count}. {hotel.Name}");
            }
        }

        public void DisplayRoomTypes(string hotelId)
        {
            int count = 0;
            Console.WriteLine("Viewing all room types: ");
            List<RoomType> types = _roomTypeService.GetSelected(type => type.HotelId == hotelId);
            foreach (RoomType type in types)
            {
                Console.WriteLine($"{++count}. {type.Name!.ToPascalCase()}");
            }
        }

        public void DisplayRoomNumbers(string roomTypeId)
        {
            Console.WriteLine("Viewing Room number(s): ");
            List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == roomTypeId);
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.Number!.PadRight(10) + $" Status: {room.RoomStatus}");
            }
        }

        public void DisplayRoomServices(string hotelId)
        {
            int count = 0;
            var services = _roomServicesService.GetSelected(service => service.HotelId == hotelId).Select(service => service.Name);
            foreach (var service in services)
            {
                Console.WriteLine($"{++count}. {service}");
            }
        }

        private void Read()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}