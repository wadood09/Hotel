using Project_TestCase2.Models.Entities;
using Project_TestCase2.Models.Extensions;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Implementation;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Menu
{
    public class AdminMenu
    {
        private bool skip = false;
        private Random random = new();
        private ConsoleColor[] colours = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow };
        IRepository<Admin> _adminRepository = new AdminRepository();
        IRepository<Hotel> _hotelRepository = new HotelRepository();
        IRoomRepository _roomRepository = new RoomRepository();
        IRoomServiceRepository _roomServiceRepository = new RoomServiceRepository();
        IRoomTypeRepository _roomTypeRepository = new RoomTypeRepository();
        IManager<Admin> _adminManager = new AdminManager();
        IHotelManager _hotelManager = new HotelManager();
        IRoomManager _roomManager = new RoomManager();
        IRoomServiceManager _roomServiceManager = new RoomServiceManager();
        IRoomTypeManager _roomTypeManager = new RoomTypeManager();
        OnStart onStart = new();
        public void MainMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== ADMIN MENU ======");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");
                int choice = 3;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t====== REGISTRATION ======");
                        Register();
                        break;
                    case 2:
                        Console.WriteLine("\t====== LOGIN ======");
                        Login();
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

        private void Register()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastname = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Admin admin = new(firstName, lastname, email, password);
            _adminManager.Register(admin);
            Read();
        }

        private void Login()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            if (_adminManager.Login(email, password))
            {
                Console.WriteLine("Login Successfull");
                Read();
                Menu();
            }
            else
            {
                Console.WriteLine("Invalid Login Details");
                Read();
            }
        }

        private void Menu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                if (!skip)
                {
                    Admin admin = _adminRepository.GetById(Admin.LoggedInAdminId);
                    Console.WriteLine($"Welcome {admin.FirstName.ToPascalCase()} {admin.LastName.ToPascalCase()}");
                    skip = true;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== MENU ======");
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
            EnterName(ref name, ref roomTypes);
            List<double> roomPrices = new();
            EnterRoomPrices(roomTypes, ref roomPrices);
            List<int> roomAmount = new();
            EnterRoomAmount(roomTypes, ref roomAmount);
            List<List<string>> roomNumbers = new();
            EnterRoomNumber(roomTypes, roomAmount, ref roomNumbers);
            double fees = 0;
            EnterCheckOutFees(ref fees);
            bool roomService = false;
            List<string> roomServices = new();
            List<double> Prices = new();
            RoomService(ref roomService, ref roomServices, ref Prices);
            Hotel hotel = new(Admin.LoggedInAdminId, name, roomService, fees);
            _hotelManager.Register(hotel);
            for (int i = 0; i < roomTypes.Count; i++)
            {
                RoomType roomType = new(hotel.Id, roomTypes[i], roomAmount[i], roomPrices[i]);
                _roomTypeRepository.Add(roomType);
                for (int j = 0; j < roomAmount[i]; j++)
                {
                    Room room = new(roomType.Id, roomNumbers[i][j]);
                    _roomRepository.Add(room);
                }
            }
            if (hotel.RoomService)
            {
                for (int i = 0; i < roomServices.Count; i++)
                {
                    RoomService service = new(hotel.Id, roomServices[i], Prices[i]);
                    _roomServiceRepository.Add(service);
                }
            }
            Read();
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
                        price = num;
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
            Console.WriteLine("Enter amount of types of rooms in hotel: ");
            foreach (string room in roomTypes)
            {
                int amount = -1;
                while (amount < 0)
                {
                    Console.Write($"{room.ToPascalCase()}:  ");
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        amount = num;
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
                Console.WriteLine($"Enter room number for rooms under {type.ToPascalCase()}");
                for (int i = 1; i <= roomAmount[index]; i++)
                {
                    string hold = Console.ReadLine();
                    while (hold == string.Empty)
                    {
                        if (hold == string.Empty)
                        {
                            Console.WriteLine("Invalid Input!!!\nTry again");
                            hold = Console.ReadLine();
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
            Console.Write("Enter early check-out fees: ");
            fees = -1;
            while (fees < 0)
            {
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    fees = num;
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
            char choice = '0';
            HaveRoomService(ref choice);
            if (char.ToUpper(choice) == 'Y')
            {
                EnterRoomService(ref roomService, ref roomServices, ref Prices);
            }
        }

        private void HaveRoomService(ref char choice)
        {
            Console.WriteLine("Do you want your hotel to provide room service? (Y/N)");
            choice = '0';
            while (choice == '0')
            {
                if (char.TryParse(Console.ReadLine().ToUpper(), out char num))
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

        private void EnterRoomService(ref bool roomService, ref List<string> roomServices, ref List<double> Prices)
        {
            Console.WriteLine("Enter types of room services your hotel provides: ");
            string input2;
            while ((input2 = Console.ReadLine()) != "")
            {
                roomServices.Add(input2);
            }
            if (roomServices.Count != 0)
            {
                Console.WriteLine("Enter price of room service(s): ");
                foreach (string service in roomServices)
                {
                    Console.Write($"{service}:  ");
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
                    Prices.Add(price);
                }
                roomService = true;
            }
            else
            {
                Console.WriteLine("Your hotel is not providing room service");
            }
        }

        private void EnterName(ref string name, ref List<string> roomTypes)
        {
            Console.Write("Enter name of hotel: ");
            name = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter types of rooms in hotel: ");
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                roomTypes.Add(input);
            }
        }

        private void ViewHotelDetails()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            if (hotel.Count == 0)
            {
                Console.WriteLine("Cannot view hotel details until hotel has been registered by user!!!");
                Read();
                return;
            }
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter which hotel to view details (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            HotelDetails(hotel, choice);
            Read();
        }

        private void HotelDetails(List<Hotel> hotel, int choice)
        {
            List<RoomType> roomTypes = _roomTypeRepository.GetAllByHotelId(hotel[choice].Id);
            List<RoomService> roomServices = _roomServiceRepository.GetByHotelId(hotel[choice].Id);
            Console.Write("Hotel Name: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine($"{hotel[choice].Name}");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine("ROOM TYPES".PadRight(20) + "AMOUNT OF ROOM".PadRight(30) + "PRICES OF ROOMS");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < roomTypes.Count; i++)
            {
                Console.WriteLine(roomTypes[i].Name.ToPascalCase().PadRight(20) + roomTypes[i].Amount.ToString().PadRight(30) + $"N{roomTypes[i].Price:n}");
            }
            if (hotel[choice].RoomService)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine($"ROOM SERVICES      PRICES");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (RoomService service in roomServices)
                {
                    Console.WriteLine(service.Name.ToPascalCase().PadRight(20) + $"N{service.Price:n}");
                }
            }
        }

        private void UpdateHotelDetails()
        {
            List<Hotel> hotels = _hotelRepository.GetList(Admin.LoggedInAdminId);
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
                    choice = num;
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
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter the which hotel to change name (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            HotelName(ref hotel, choice);
            Read();
        }

        private void HotelName(ref List<Hotel> hotel, int choice)
        {
            Console.Write("Enter new hotel name: ");
            string hotelName = Console.ReadLine().ToUpper();
            if (_hotelManager.IsExist(hotelName))
            {
                Console.WriteLine($"Hotel with name '{hotelName}' already exists");
                Console.WriteLine("Update Unsuccessfull");
            }
            else
            {
                hotel[choice].Name = hotelName;
                Console.WriteLine($"You have successfully changed your hotel name to {hotelName}");
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
                    choice = num;
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
                        AddRooms();
                        break;
                    case 6:
                        Console.WriteLine("\t======REMOVING ROOM======");
                        RemoveRooms();
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
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter the which hotel to add room type (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Add(hotel, choice);
            Read();
        }

        private void Add(List<Hotel> hotel, int choice)
        {
            Console.Write("Enter room type to add: ");
            string roomType = Console.ReadLine();
            if (_roomTypeManager.IsExist(roomType, hotel[choice].Id))
            {
                Console.WriteLine($"Room Type {roomType} already exists");
                Console.WriteLine("Unable to add room type");
                Console.WriteLine("Update Unsuccessfull");
                return;
            }
            Console.Write("Enter price of room type: ");
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
            Console.Write("Enter amount of room type: ");
            int amount = -1;
            while (amount < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    amount = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            RoomType type = new(hotel[choice].Id, roomType, amount, price);
            Console.WriteLine($"Enter room numbers of rooms under type {roomType}");
            for (int i = 1; i <= amount; i++)
            {
                string num = Console.ReadLine();
                _roomRepository.Add(new Room(type.Id, num));
            }
            _roomTypeRepository.Add(type);
            Console.WriteLine($"Room type {roomType} added successfully");
        }

        private void RemoveRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            onStart.CheckRoomTypeStatus();
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Remove(hotel, choice);
            Read();
        }

        private void Remove(List<Hotel> hotel, int choice)
        {
            _roomTypeManager.DisplayNames(hotel[choice].Id);
            Console.Write("Enter room type to remove: ");
            int number = -1;
            while (number < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    number = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (_roomTypeManager.IsExist(number, hotel[choice].Id))
            {
                if (_roomTypeRepository.Get(hotel[choice].Id, number).Status == Models.Enums.RoomTypeStatus.Available)
                {
                    Console.WriteLine($"Cannot remove room type because it is being occupied!!!\nTry again later");
                    return;
                }
                List<Room> rooms = _roomRepository.GetByRoomTypeId(_roomTypeRepository.Get(hotel[choice].Id, number).Id);
                foreach (Room room in rooms)
                {
                    _roomRepository.Remove(room);
                }
                _roomTypeRepository.Remove(_roomTypeRepository.Get(hotel[choice].Id, number));
                Console.WriteLine($"Successfully removed room type");
            }
            else
            {
                Console.WriteLine($"Room Type does not exists");
                Console.WriteLine("Unable to remove room type");
                Console.WriteLine("Update Unsuccessfull");
            }
        }

        private void ChangePriceOfRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter the which hotel to update room prices (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            ChangePrice(hotel, choice);
            Read();
        }

        private void ChangePrice(List<Hotel> hotel, int choice)
        {
            _roomTypeManager.DisplayNames(hotel[choice].Id);
            Console.Write("Enter which room type price to change: ");
            int number = -1;
            while (number < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    number = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (_roomTypeManager.IsExist(number, hotel[choice].Id))
            {
                Console.Write("Enter new price: ");
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
                _roomTypeRepository.Get(hotel[choice].Id, number).Price = price;
                Console.WriteLine($"Price of room type has been successfully changed to N{price:n}");
            }
            else
            {
                Console.WriteLine($"Room Type  does not exists");
                Console.WriteLine("Unable to change price of unavailable room type");
                Console.WriteLine("Update Unsuccessfull");
            }
        }

        private void ChangeAmountOfRoomType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter the which hotel to update room amount (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            ChangeAmount(hotel, choice);
            Read();
        }

        private void ChangeAmount(List<Hotel> hotel, int choice)
        {
            _roomTypeManager.DisplayNames(hotel[choice].Id);
            Console.Write("Enter which room type amount to change: ");
            int number = -1;
            while (number < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    number = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (_roomTypeManager.IsExist(number, hotel[choice].Id))
            {
                RoomType type = _roomTypeRepository.Get(hotel[choice].Id, number);
                Console.Write("Enter new amount: ");
                int amount = -1;
                while (amount < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        amount = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (amount > type.Amount)
                {
                    Console.WriteLine("Enter room numbers of newly added rooms: ");
                    for (int i = 1; i <= amount - type.Amount; i++)
                    {
                        string num = Console.ReadLine();
                        _roomRepository.Add(new Room(type.Id, num));
                    }
                }
                else
                {
                    Console.WriteLine($"The new amount of room type {type.Name} is lower than the former amount.");
                    _roomManager.DisplayRoomNumbers(type.Id);
                    Console.WriteLine("Enter room number of rooms to be removed");
                    for (int i = 1; i <= type.Amount - amount; i++)
                    {
                        string num = Console.ReadLine();
                        if (_roomManager.IsExist(num, type.Id))
                        {
                            _roomRepository.Remove(_roomRepository.GetByRoomNumber(num, type.Id));
                        }
                        else
                        {
                            Console.WriteLine("Room number does not exist!!!Try again");
                            i--;
                        }
                    }
                }
                type.Amount = amount;
                Console.WriteLine($"Amount of room type has been successfully changed to {amount}");
            }
            else
            {
                Console.WriteLine($"Room Type does not exists");
                Console.WriteLine("Unable to change amount of unavailable room type");
                Console.WriteLine("Update Unsuccessfull!!!");
            }
        }

        private void AddRooms()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            _roomTypeManager.DisplayNames(hotel[choice].Id);
            Console.Write("Under which room type is room to be added: ");
            int number = -1;
            while (number < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    number = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (_roomTypeManager.IsExist(number, hotel[choice].Id))
            {
                RoomType type = _roomTypeRepository.Get(hotel[choice].Id, number);
                Console.Write("Enter room number of room to be added: ");
                string num = Console.ReadLine();
                _roomRepository.Add(new Room(type.Id, num));
                Console.WriteLine("Room added successfully!!!");
            }
            else
            {
                Console.WriteLine($"Room type does not exist!!!");
            }
            Read();
        }

        private void RemoveRooms()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            _roomTypeManager.DisplayNames(hotel[choice].Id);
            Console.Write("Under which room type does room to be removed exists: ");
            int number = -1;
            while (number < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    number = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (_roomTypeManager.IsExist(number, hotel[choice].Id))
            {
                bool isContinue = true;
                while (isContinue)
                {
                    RoomType type = _roomTypeRepository.Get(hotel[choice].Id, number);
                    _roomManager.DisplayRoomNumbers(type.Id);
                    Console.Write("Enter room number of room to be removed: ");
                    string num = Console.ReadLine();
                    if (_roomManager.IsExist(num, type.Id))
                    {
                        if (_roomRepository.GetByRoomNumber(num, type.Id).RoomStatus == Models.Enums.RoomStatus.Occupied)
                        {
                            Console.WriteLine("Cannot remove room because room is being occupied!!!");
                        }
                        else
                        {
                            _roomRepository.Remove(_roomRepository.GetByRoomNumber(num, type.Id));
                            Console.WriteLine("Room removed successfully!!!");
                            isContinue = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Room number {num} does not exist!!!Try again");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Room type does not exist!!!");
            }
            Read();
        }

        private void ChangeRoomNumber()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            _roomTypeManager.DisplayNames(hotel[choice].Id);
            Console.Write("Under which room type is room number to be changed: ");
            int number = -1;
            while (number < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    number = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (_roomTypeManager.IsExist(number, hotel[choice].Id))
            {
                RoomType type = _roomTypeRepository.Get(hotel[choice].Id, number);
                _roomManager.DisplayRoomNumbers(type.Id);
                Console.Write("Enter room number of room to be changed: ");
                string num = Console.ReadLine();
                if (_roomManager.IsExist(num, type.Id))
                {
                    Console.Write("Enter new room number: ");
                    string newnum = Console.ReadLine();
                    if (!_roomManager.IsExist(newnum, type.Id))
                    {
                        _roomRepository.GetByRoomNumber(num, type.Id).Number = newnum;
                        Console.WriteLine($"You have successfully changed room's room number to {newnum}");
                    }
                    else
                    {
                        Console.WriteLine($"A room with {newnum} room number already exists within the same type!!!");
                    }
                }
                else
                {
                    Console.WriteLine($"Room with room number {num} does not exist!!!");
                }
            }
            else
            {
                Console.WriteLine($"Room type does not exist!!!");
            }
            Read();
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
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter which hotel to view details (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            char input = 'Y';
            if (!hotel[choice].RoomService)
            {
                Console.WriteLine("Are you sure you want your hotel to be providing room service (Y/N)");
                input = '0';
                while (input == '0')
                {
                    if (char.TryParse(Console.ReadLine().ToUpper(), out char num))
                    {
                        input = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
            }
            if (input == 'Y')
            {
                List<string> roomServices = new();
                Console.WriteLine("Enter types of room services to be added: ");
                string input2;
                while ((input2 = Console.ReadLine()) != "")
                {
                    if (!_roomServiceManager.IsExist(input2, hotel[choice].Id))
                    {
                        roomServices.Add(input2);
                    }
                    else
                    {
                        Console.WriteLine($"{input2} room type already exists!!!");
                    }
                }
                Console.WriteLine("Enter price of room service(s): ");
                foreach (string service in roomServices)
                {
                    double price = -1;
                    while (price < 0)
                    {
                        Console.Write($"{service}:  ");
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
                    _roomServiceRepository.Add(new RoomService(hotel[choice].Id, service, price));
                }
                hotel[choice].RoomService = true;
                Console.WriteLine("Room service(s) has been added successfully!!!");
            }
            else
            {
                Console.WriteLine("Your hotel is not providing room service");
                hotel[choice].RoomService = false;
            }
            Read();
        }

        private void RemoveRoomService()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            onStart.CheckHotelStatus();
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                _hotelManager.DisplayHotels(Admin.LoggedInAdminId);
                Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            if (hotel[choice].HotelStatus == Models.Enums.HotelStatus.Active)
            {
                Console.WriteLine("Cannot remove room service because hotel status is active!!!\nTry again later");
                Read();
                return;
            }
            if (!hotel[choice].RoomService)
            {
                Console.WriteLine("Cannot remove room service because your hotel isn't providing room service!!!");
                Console.WriteLine("Kindly add room service in order to remove room sevice.");
                Console.WriteLine("Thank you");
            }
            else
            {
                _roomServiceManager.DisplayNames(hotel[choice].Id);
                Console.WriteLine("Enter name of room service to be removed (i.e enter 1,2,3,...)");
                int number = -1;
                while (number < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        number = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (_roomServiceManager.IsExist(name, hotel[choice].Id))
                {
                    _roomServiceRepository.Remove(_roomServiceRepository.Get(name, hotel[choice].Id));
                    Console.WriteLine($"{name} room service has been removed successfully!!!");
                }
                else
                {
                    Console.WriteLine($"No existing room service with name {name}!!!");
                }
            }
            Read();
        }

        private void ChangePriceOfRoomService()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            if (!hotel[choice].RoomService)
            {
                Console.WriteLine("Cannot change room service price because your hotel isn't providing room service!!!");
                Console.WriteLine("Kindly add room service in order to change room sevice price.");
                Console.WriteLine("Thank you");
            }
            else
            {
                Console.Write("Enter name of room service of price to be changed: ");
                string name = Console.ReadLine();
                if (_roomServiceManager.IsExist(name, hotel[choice].Id))
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
                    _roomServiceRepository.Get(name, hotel[choice].Id).Price = price;
                    Console.WriteLine($"{name} price has been successfully changed to N{price:n}");
                }
                else
                {
                    Console.WriteLine($"No existing room service with name {name}!!!");
                }
            }
            Read();
        }

        private void ChangeCheckOutFees()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = -1;
                while (choice < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        choice = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
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

        private void RemoveHotel()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            onStart.CheckHotelStatus();
            Console.WriteLine("All details about hotel will be removed including room types, room services, etc");
            Console.WriteLine("Are you sure you want to remove hotel (Y/N)");
            char choice = '0';
            while (choice == '0')
            {
                if (char.TryParse(Console.ReadLine().ToUpper(), out char num))
                {
                    choice = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (choice != 'Y')
            {
                return;
            }
            Console.Write("Enter name of hotel to be removed: ");
            string name = Console.ReadLine();
            Hotel hotel = _hotelRepository.GetByName(name);
            if (hotel is null)
            {
                Console.WriteLine($"Hotel with name {name.ToPascalCase()} does not exist!!!\nTry again later");
            }
            else
            {
                if (_hotelManager.IsOwner(hotel, Admin.LoggedInAdminId))
                {
                    if (hotel.HotelStatus == Models.Enums.HotelStatus.Active)
                    {
                        Console.WriteLine("Hotel status is active and therefore cannot remove hotel!!!\nTry again later");
                        Read();
                        return;
                    }
                    List<RoomService> services = _roomServiceRepository.GetByHotelId(hotel.Id);
                    List<RoomType> types = _roomTypeRepository.GetAllByHotelId(hotel.Id);
                    List<List<Room>> rooms = new();
                    foreach (RoomType type in types)
                    {
                        rooms.Add(_roomRepository.GetByRoomTypeId(type.Id));
                    }
                    foreach (RoomService service in services)
                    {
                        _roomServiceRepository.Remove(service);
                    }
                    for (int i = 0; i < types.Count; i++)
                    {
                        for (int j = 0; j < rooms[i].Count; j++)
                        {
                            _roomRepository.Remove(rooms[i][j]);
                        }
                        _roomTypeRepository.Remove(types[i]);
                    }
                    _hotelRepository.Remove(hotel);
                    Console.WriteLine($"{name} hotel has been removed successfully!!!");
                }
                else
                {
                    Console.WriteLine($"Hotel {name} is not registered under user's name and therefore cannot be removed by user!!!");
                }
            }
            Read();
        }

        private void DeleteAccount()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            onStart.CheckHotelStatus();
            Console.WriteLine("All details about user will be removed if user deletes account");
            Console.WriteLine("Do you want to continue with this operation (Y/N)");
            char choice = '0';
            while (choice == '0')
            {
                if (char.TryParse(Console.ReadLine().ToUpper(), out char num))
                {
                    choice = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (choice == 'Y')
            {
                Admin admin = _adminRepository.GetById(Admin.LoggedInAdminId);
                if (admin is null)
                {
                    Console.WriteLine("Account not found!!! \nAccount must be registered in order to delete account");
                    Read();
                    return;
                }
                List<Hotel> hotels = _hotelRepository.GetList(Admin.LoggedInAdminId);
                foreach (Hotel hotel in hotels)
                {
                    if (hotel.HotelStatus == Models.Enums.HotelStatus.Active)
                    {
                        Console.WriteLine("Hotel status is active and therefore cannot remove hotel!!!\nTry again later");
                        Read();
                        return;
                    }
                }
                foreach (Hotel hotel in hotels)
                {
                    List<RoomService> services = _roomServiceRepository.GetByHotelId(hotel.Id);
                    List<RoomType> types = _roomTypeRepository.GetAllByHotelId(hotel.Id);
                    List<List<Room>> rooms = new();
                    foreach (RoomType type in types)
                    {
                        rooms.Add(_roomRepository.GetByRoomTypeId(type.Id));
                    }
                    foreach (RoomService service in services)
                    {
                        _roomServiceRepository.Remove(service);
                    }
                    for (int i = 0; i < types.Count; i++)
                    {
                        for (int j = 0; j < rooms[i].Count; j++)
                        {
                            _roomRepository.Remove(rooms[i][j]);
                        }
                        _roomTypeRepository.Remove(types[i]);
                    }
                    _hotelRepository.Remove(hotel);
                }
                _adminRepository.Remove(admin);
                Console.WriteLine("Account has been deleted successfully!!!");
                Read();
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