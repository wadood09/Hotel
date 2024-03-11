using My_Dapper_Project.Helper.Extensions;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Services.Implementation;
using My_Dapper_Project.Services.Interface;
using My_Dapper_Project.Models.Enums;

namespace My_Dapper_Project.Menu
{
    public class AdminMenu
    {
        private bool skip = false;
        private Random random = new();
        private ConsoleColor[] colours = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow };
        IAdminService _adminService = new AdminService();
        IHotelService _hotelService = new HotelService();
        IRoomService _roomService = new RoomServices();
        IRoomServicesService _roomServicesService = new RoomServicesService();
        IRoomTypeService _roomTypeService = new RoomTypeService();
        IUserService _userService = new UserService();
        GeneralMenu generalMenu = new();
        public void MainMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                if (!skip)
                {
                    User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "ADMIN")!;
                    Console.WriteLine($"Welcome {user.FirstName.ToPascalCase()} {user.LastName.ToPascalCase()}");
                    skip = true;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t========== ADMIN MENU ==========");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Register Hotel");
                Console.WriteLine("2. Check Wallet Balance");
                Console.WriteLine("3. View Hotel Details");
                Console.WriteLine("4. View Room Details");
                Console.WriteLine("5. Update Hotel Details");
                Console.WriteLine("6. Remove Hotel");
                Console.WriteLine("7. Delete Account");
                Console.WriteLine("0. Logout");
                int choice = 8;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t========== REGISTERING HOTEL ==========");
                        RegisterHotel();
                        break;
                    case 2:
                        Console.WriteLine("\t========== VIEWING WALLET BALANCE ==========");
                        generalMenu.CheckBalance("ADMIN");
                        Read();
                        break;
                    case 3:
                        Console.WriteLine("\t========== VIEWING HOTEL DETAILS ==========");
                        ViewHotelDetails();
                        break;
                    case 4:
                        Console.WriteLine("\t========== VIEWING ROOM DETAILS ==========");
                        ViewRoomDetails();
                        break;
                    case 5:
                        UpdateHotelDetails();
                        break;
                    case 6:
                        Console.WriteLine("\t========== REMOVING HOTEL ==========");
                        RemoveHotel();
                        break;
                    case 7:
                        Console.WriteLine("\t========== DELETING ACCOUNT ==========");
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

            List<string> roomServices = new();
            List<double> prices = new();
            EnterRoomService(ref roomServices, ref prices, 0);

            Hotel? hotel = _hotelService.CreateHotel(name, roomTypes, roomPrices, roomAmount, roomNumbers, roomServices, prices);
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

        private void EnterRoomService(ref List<string> roomServices, ref List<double> Prices, int hotelId)
        {
            Console.WriteLine("Enter additional room services you want your hotel to be providing: ");
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
                    generalMenu.EnterChoice(ref price);
                    Prices.Add(price);
                }
            }
            else
            {
                Console.WriteLine("Your hotel is not providing room service");
            }
        }

        private void ViewHotelDetails()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseHotel(out List<Hotel> hotel, out int choice);
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
            Console.WriteLine("ROOM TYPES".PadRight(20) + "AMOUNT OF ROOM".PadRight(20) + "PRICES OF ROOMS");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < roomTypes.Count; i++)
            {
                Console.WriteLine(roomTypes[i].Name!.ToPascalCase().PadRight(20) + roomTypes[i].AmountOfRooms.ToString().PadRight(20) + $"N{roomTypes[i].Price:n}");
            }

            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine("ROOM SERVICES".PadRight(20) + "PRICES");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (RoomService service in roomServices)
            {
                Console.WriteLine(service.Name!.ToPascalCase().PadRight(20) + $"N{service.Price:n}");
            }
        }

        private void ViewRoomDetails()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            RoomDetails(hotel[choice]);
            Read();
        }

        private void RoomDetails(Hotel hotel)
        {
            generalMenu.DisplayRoomTypes(hotel.Id);
            Console.WriteLine("Choose which room type to view rooms' details (i.e enter 1,2,3,...): ");

            int choice = new();
            generalMenu.EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                generalMenu.DisplayRooms(type.Id);
            }
            else
            {
                Console.WriteLine($"Room type chosen does not exist!!!");
            }
        }

        private void ChooseHotel(out List<Hotel> hotel, out int choice)
        {
            hotel = _hotelService.GetSelected(hotel => hotel.AdminId == Admin.LoggedInAdminId);
            User? user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "ADMIN");
            if (user is null)
            {
                Console.WriteLine("User must be registered in order to access this function!!!");
                choice = -1;
                Read();
                return;
            }
            choice = 1;
            if (hotel.Count == 0)
            {
                Console.WriteLine("Cannot view hotel details until hotel has been registered by user!!!");
                choice = -1;
                Read();
                return;
            }
            else if (hotel.Count > 1)
            {
                DisplayHotels(Admin.LoggedInAdminId!);
                Console.WriteLine("Choose one of the hotels displayed above (i.e enter 1,2,3,...): ");
                choice = new();
                generalMenu.EnterChoice(ref choice);

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
            ChooseHotel(out List<Hotel> hotel, out int choice);
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
                Console.WriteLine("Update successfull!!!");
                _hotelService.Update(hotel[choice]);
            }
        }

        private void UpdateRoomTypes()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t========== UPDATING ROOM TYPES ==========");
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
                        Console.WriteLine("\t========== ADDING ROOM TYPE ==========");
                        AddRoomType();
                        break;
                    case 2:
                        Console.WriteLine("\t========== REMOVING ROOM TYPE ==========");
                        RemoveRoomType();
                        break;
                    case 3:
                        Console.WriteLine("\t========== CHANGING PRICE OF ROOM TYPE ==========");
                        ChangePriceOfRoomType();
                        break;
                    case 4:
                        Console.WriteLine("\t========== CHANGING AMOUNT OF ROOM TYPE ==========");
                        ChangeAmountOfRoomType();
                        break;
                    case 5:
                        Console.WriteLine("\t========== ADDING ROOM ==========");
                        AddRoom();
                        break;
                    case 6:
                        Console.WriteLine("\t========== REMOVING ROOM ==========");
                        RemoveRoom();
                        break;
                    case 7:
                        Console.WriteLine("\t========== CHANGING ROOM NUMBER ==========");
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
            ChooseHotel(out List<Hotel> hotel, out int choice);
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

        private void EnterType(ref string? name, int hotelId)
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
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            generalMenu.CheckRoomTypeStatus(hotel[choice].Id);
            RemoveRoomType(hotel[choice]);
            Read();
        }

        private void RemoveRoomType(Hotel hotel)
        {
            generalMenu.DisplayRoomTypes(hotel.Id);
            int choice = new();

            Console.Write("Choose which room type to remove (i.e enter 1,2,3,...) ");
            generalMenu.EnterChoice(ref choice);

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

        private void ChangePriceOfRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            ChangePriceOfRoomType(hotel[choice]);
            Read();
        }

        private void ChangePriceOfRoomType(Hotel hotel)
        {
            generalMenu.DisplayRoomTypes(hotel.Id);
            Console.WriteLine("Choose which room type price to be changed (i.e enter 1,2,3,...) ");
            int choice = new();
            generalMenu.EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                Console.Write("Enter new price: ");
                double price = new();
                generalMenu.EnterChoice(ref price);

                type.Price = price;
                Console.WriteLine($"Price of room type has been successfully changed to N{price:n}");
                _roomTypeService.Update(type);
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
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            ChangeAmountOfRoomType(hotel[choice]);
            Read();
        }

        private void ChangeAmountOfRoomType(Hotel hotel)
        {
            generalMenu.DisplayRoomTypes(hotel.Id);
            Console.Write("Choose which room type amount to change: ");
            int choice = new();
            generalMenu.EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                generalMenu.CheckRoomStatus(type.Id);
                Console.Write("Enter new amount of rooms: ");
                int amount = new();
                generalMenu.EnterChoice(ref amount);

                if (amount > type.AmountOfRooms)
                {
                    int times = amount - type.AmountOfRooms;
                    Console.WriteLine($"The new amount of room type {type.Name} is higher than the former amount!!!");
                    Console.WriteLine($"Rooms to be added: {times}");
                    Console.WriteLine("Enter room numbers of newly added rooms: ");
                    CreateRoom(times, hotel.Id, type.Id);
                }
                else
                {
                    int times = type.AmountOfRooms - amount;
                    Console.WriteLine($"The new amount of room type {type.Name} is lower than the former amount!!!");
                    List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == type.Id && room.RoomStatus == RoomStatus.Vacant);
                    // Checking whether rooms to be removed is available
                    if (rooms.Count < times)
                    {
                        Console.WriteLine("The available rooms that can be removed is less than the amount of rooms to be removed!!!");
                        Console.WriteLine("Unable to change amount of rooms available!!!");
                        Console.WriteLine("Update Unsuccessfull!!!");
                        return;
                    }
                    Console.WriteLine($"Rooms to be removed: {times}");
                    generalMenu.DisplayRooms(type.Id);
                    Console.WriteLine("Enter room number of rooms to be removed");
                    RemoveRoom(times, type.Id);
                }
                type.AmountOfRooms = amount;
                Console.WriteLine($"Amount of room type has successfully been changed to {amount}");
                _roomTypeService.Update(type);
            }
            else
            {
                Console.WriteLine($"Room Type chosen does not exists");
                Console.WriteLine("Unable to change amount of unavailable room type");
                Console.WriteLine("Update Unsuccessfull!!!");
            }
        }

        private void CreateRoom(int times, int hotelId, int roomTypeId)
        {
            int remains = times;
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
                remains--;
                _roomService.CreateRoom(roomTypeId, num);
                Console.WriteLine($"Remaining rooms to be added: {remains}");
            }
        }

        private void RemoveRoom(int times, int roomTypeId)
        {
            int remains = times;
            for (int i = 1; i <= times; i++)
            {
                string num = Console.ReadLine()!;
                if (_roomService.IsExist(num, roomTypeId))
                {
                    Room room = _roomService.Get(room => room.RoomTypeId == roomTypeId && room.RoomNumber == num)!;
                    bool isDeleted = _roomService.IsDeleted(room);
                    if (!isDeleted)
                    {
                        Console.WriteLine("Cannot remove occupied or booked room!!!\nTry Again");
                        i--;
                    }
                    else
                    {
                        remains--;
                        Console.WriteLine($"Remaining rooms to be removed: {remains}");
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
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            AddRoom(hotel[choice]);
            Read();
        }

        private void AddRoom(Hotel hotel)
        {
            generalMenu.DisplayRoomTypes(hotel.Id);

            Console.Write("Under which room type is room to be added: ");
            int choice = new();
            generalMenu.EnterChoice(ref choice);

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
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            RemoveRoom(hotel[choice]);
            Read();
        }

        private void RemoveRoom(Hotel hotel)
        {
            generalMenu.DisplayRoomTypes(hotel.Id);
            Console.Write("Under which room type does room to be removed exists: ");
            int choice = new();
            generalMenu.EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                generalMenu.CheckRoomStatus(type.Id);
                List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == type.Id && room.RoomStatus == RoomStatus.Vacant);
                if (!rooms.Any())
                {
                    Console.WriteLine("No available room to be removed!!!\nTry again later");
                    return;
                }

                generalMenu.DisplayRooms(type.Id);
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
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            ChangeRoomNumber(hotel[choice]);
            Read();
        }

        private void ChangeRoomNumber(Hotel hotel)
        {
            generalMenu.DisplayRoomTypes(hotel.Id);

            Console.Write("Under which room type is room number to be changed: ");
            int choice = new();
            generalMenu.EnterChoice(ref choice);

            RoomType? type = _roomTypeService.IsExist(choice, hotel.Id);
            if (type is not null)
            {
                generalMenu.CheckRoomStatus(type.Id);
                List<Room> rooms = _roomService.GetSelected(room => room.RoomTypeId == type.Id && room.RoomStatus == RoomStatus.Vacant);
                if (!rooms.Any())
                {
                    Console.WriteLine("No available room to be changed!!!\nTry again later");
                    return;
                }

                generalMenu.DisplayRooms(type.Id);
                Console.Write("Enter room number of room to be changed: ");
                ChangeRoomNumber(type.Id);
            }
            else
            {
                Console.WriteLine($"Room type does not exist!!!");
            }
        }

        private void ChangeRoomNumber(int roomTypeId)
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
                    Room room = _roomService.Get(room => room.RoomTypeId == roomTypeId && room.RoomNumber == num)!;
                    room.RoomNumber = newNum;
                    Console.WriteLine($"You have successfully changed room's room number to {newNum}");
                    _roomService.Update(room);
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
                Console.WriteLine("\t========== UPDATING ROOM SERVICES ==========");
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
                        Console.WriteLine("\t========== ADDING ROOM SERVICE ==========");
                        AddRoomService();
                        break;
                    case 2:
                        Console.WriteLine("\t========== REMOVING ROOM SERVICE ==========");
                        RemoveRoomService();
                        break;
                    case 3:
                        Console.WriteLine("\t========== CHANGING PRICE OF ROOM SERVICE ==========");
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
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            AddRoomService(ref hotel, choice);
            Read();
        }

        private void AddRoomService(ref List<Hotel> hotel, int choice)
        {
            List<string> roomServices = new();
            List<double> prices = new();
            EnterRoomService(ref roomServices, ref prices, hotel[choice].Id);

            for (int i = 0; i < prices.Count; i++)
            {
                _roomServicesService.CreateRoomService(hotel[choice].Id, roomServices[i], prices[i]);
            }
            Console.WriteLine("Room service(s) has been added successfully!!!");
        }

        private void RemoveRoomService()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            generalMenu.CheckHotelStatus();

            RemoveRoomService(ref hotel, choice);
            Read();
        }

        private void RemoveRoomService(ref List<Hotel> hotel, int choice)
        {
            if (hotel[choice].HotelStatus == Status.Active)
            {
                Console.WriteLine("Cannot remove room service because hotel status is active!!!\nTry again later");
                return;
            }
            else
            {
                Hotel hotel1 = hotel[choice];
                List<RoomService> services = _roomServicesService.GetSelected(service => service.HotelId == hotel1.Id);
                if (services.Count == 1)
                {
                    Console.WriteLine("Unable to remove room service!!!");
                    Console.WriteLine("Hotel must be providing at least one additional room service!!!");
                    return;
                }
                generalMenu.DisplayRoomServices(hotel1.Id);
                Console.WriteLine("Choose which room service to be removed (i.e enter 1,2,3,...)");

                int number = new();
                generalMenu.EnterChoice(ref number);

                RoomService? service = _roomServicesService.IsExist(number, hotel1.Id);
                if (service is not null)
                {
                    _roomServicesService.Delete(service);
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
            ChooseHotel(out List<Hotel> hotel, out int choice);
            if (choice < 0) return;

            ChangePriceOfRoomService(hotel[choice]);
            Read();
        }

        private void ChangePriceOfRoomService(Hotel hotel)
        {
            generalMenu.DisplayRoomServices(hotel.Id);

            Console.WriteLine("Choose which room service price to be changed (i.e enter 1,2,3,...)");
            int choice = new();
            generalMenu.EnterChoice(ref choice);

            RoomService? service = _roomServicesService.IsExist(choice, hotel.Id);
            if (service is not null)
            {
                Console.Write("Enter new price of room service: ");
                double price = new();
                generalMenu.EnterChoice(ref price);

                service.Price = price;
                Console.WriteLine($"Price of chosen room service has been successfully changed to N{price:n}");
                _roomServicesService.Update(service);
            }
            else
            {
                Console.WriteLine($"The room service chosen does not exist!!!");
            }
        }

        private void RemoveHotel()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            generalMenu.CheckHotelStatus();
            Console.WriteLine("All details about hotel will be removed including room types, room services, etc");
            Console.WriteLine("Are you sure you want to remove hotel (Y/N)");

            char choice = new();
            generalMenu.EnterChoice(ref choice);

            if (choice != 'Y')
            {
                Read();
                return;
            }

            ChooseHotel(out List<Hotel> hotel, out int choice2);
            if (choice2 < 0) return;

            else
            {
                if (hotel[choice2].HotelStatus == Status.Active)
                {
                    Console.WriteLine("Hotel status is active and therefore cannot remove hotel!!!\nTry again later");
                    Read();
                    return;
                }

                bool isDeleted = _hotelService.IsDeleted(hotel[choice2]);
                if (isDeleted)
                    Console.WriteLine("Hotel has been removed successfully!!!");
                else
                    Console.WriteLine($"Unable to remove Hotel if hotel is active!!!\nHotel Removal Unsuccessfull!!!");
            }
            Read();
        }

        private void DeleteAccount()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            generalMenu.CheckHotelStatus();
            Console.WriteLine("All details about user will be removed if user deletes account");
            Console.WriteLine("Do you want to continue with this operation (Y/N)");

            char choice = new();
            generalMenu.EnterChoice(ref choice);

            if (choice == 'Y')
            {
                Admin? admin = _adminService.Get(admin => admin.Id == Admin.LoggedInAdminId);
                if (admin is null)
                {
                    Console.WriteLine("Account not found!!! \nAccount must be registered in order to delete account");
                    Read();
                    return;
                }
                bool isDeleted = _adminService.IsDeleted(admin);
                if (isDeleted)
                    Console.WriteLine("Account has been deleted successfully!!!");
                else
                    Console.WriteLine("Account cannot be deleted because some hotels are active!!!\nTry again later");
                Read();
            }
        }

        public void DisplayHotels(int adminId)
        {
            int count = 0;
            Console.WriteLine("Viewing all hotels: ");
            List<Hotel> hotels = _hotelService.GetSelected(hotel => hotel.AdminId == adminId);
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine($"{++count}. {hotel.Name}");
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