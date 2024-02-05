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
        public void MainMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {

                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 0:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void Register()
        {
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
            Admin admin = _adminRepository.GetById(Admin.LoggedInAdminId);
            Console.WriteLine($"Welcome {admin.FirstName.ToPascalCase()} {admin.LastName.ToPascalCase()}");
            bool isContinue = true;
            while (isContinue)
            {

                Console.WriteLine("1. Register Hotel");
                Console.WriteLine("2. View Hotel Details");
                Console.WriteLine("3. Update Hotel Details");
                Console.WriteLine("4. Remove Hotel");
                Console.WriteLine("5. Delete Account");
                Console.WriteLine("0. Logout");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        RegisterHotel();
                        break;
                    case 2:
                        ViewHotelDetails();
                        break;
                    case 3:
                        UpdateHotelDetails();
                        break;
                    case 4:
                        RemoveHotel();
                        break;
                    case 5:
                        DeleteAccount();
                        break;
                    case 0:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;

                }
            }
        }

        private void RegisterHotel()
        {
            Console.Write("Enter name of hotel: ");
            string name = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter types of rooms in hotel: ");
            List<string> roomTypes = new();
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                roomTypes.Add(input);
            }
            Console.WriteLine("Enter prices of rooms in hotel: ");
            List<double> roomPrices = new();
            foreach (string room in roomTypes)
            {
                Console.Write($"{room}:  ");
                double price = double.Parse(Console.ReadLine());
                roomPrices.Add(price);
            }
            Console.WriteLine("Enter amount of types of rooms in hotel: ");
            List<int> roomAmount = new();
            foreach (string room in roomTypes)
            {
                Console.Write($"{room}:  ");
                int amount = int.Parse(Console.ReadLine());
                roomAmount.Add(amount);
            }
            List<List<string>> roomNumbers = new();
            foreach (string type in roomTypes)
            {
                int index = 0;
                List<string> roomNumber = new();
                Console.WriteLine($"Enter room number for rooms under {type} type");
                for (int i = 1; i <= roomAmount[index]; i++)
                {
                    roomNumber.Add(Console.ReadLine());
                }
                roomNumbers.Add(roomNumber);
                index++;
            }
            Console.WriteLine("Do you want your hotel to provide room service? (Y/N)");
            bool roomService = false;
            char choice = char.Parse(Console.ReadLine().ToUpper());
            List<string> roomServices = new();
            List<double> Prices = new();
            if (char.ToUpper(choice) == 'Y')
            {
                Console.WriteLine("Enter types of room services your hotel provides: ");
                string input2;
                while ((input = Console.ReadLine()) != "")
                {
                    roomServices.Add(input);
                }
                Console.WriteLine("Enter price of room service(s): ");
                foreach (string service in roomServices)
                {
                    Console.Write($"{service}:  ");
                    double price = double.Parse(Console.ReadLine());
                    Prices.Add(price);
                }
                roomService = true;
            }
            Hotel hotel = new(Admin.LoggedInAdminId, name, roomService);
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

        private void ViewHotelDetails()
        {
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
                Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            List<RoomType> roomTypes = _roomTypeRepository.GetAll(hotel[choice].Id);
            List<RoomService> roomServices = _roomServiceRepository.GetByHotelId(hotel[choice].Id);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t{hotel[choice].Name}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"ROOM TYPES     AMOUNT OF ROOM      PRICES OF ROOMS");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < roomTypes.Count; i++)
            {
                Console.WriteLine($"{roomTypes[i].Name}     {roomTypes[i].Amount}       N{roomTypes[i].Price}:n");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"ROOM SERVICES      PRICES");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (RoomService service in roomServices)
            {
                Console.WriteLine($"{service.Name}      N{service.Price:n}");
            }
            Read();
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
                Console.WriteLine("1. Hotel Name");
                Console.WriteLine("2. Rooms");
                Console.WriteLine("3. Room Service");
                Console.WriteLine("0. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UpdateHotelName();
                        break;
                    case 2:
                        UpdateRoomTypes();
                        break;
                    case 3:
                        UpdateRoomService();
                        break;
                    case 0:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void UpdateHotelName()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to change name (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Enter new hotel name: ");
            string hotelName = Console.ReadLine().ToUpper();
            if (_hotelManager.IsExist(hotelName))
            {
                Console.WriteLine($"Hotel with name '{hotelName}' already exists");
                Console.WriteLine("Update Unsuccessfull");
                Read();
            }
            else
            {
                hotel[choice].Name = hotelName;
                Console.WriteLine($"You have successfully changed your hotel name to {hotelName}");
                Read();
            }
        }

        private void UpdateRoomTypes()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("1. Add Room Type");
                Console.WriteLine("2. Remove Room Type");
                Console.WriteLine("3. Change price of existing Room Type");
                Console.WriteLine("4. Change amount of rooms available in Room Type");
                Console.WriteLine("5. Add Room");
                Console.WriteLine("6. Remove Room");
                Console.WriteLine("0. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddRoomType();
                        break;
                    case 2:
                        RemoveRoomType();
                        break;
                    case 3:
                        ChangePriceOfRoomType();
                        break;
                    case 4:
                        ChangeAmount();
                        break;
                    case 5:
                        AddRoom();
                        break;
                    case 6:
                        RemoveRoom();
                        break;
                    case 0:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void AddRoomType()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to add room type (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Enter room type to add: ");
            string roomType = Console.ReadLine();
            if (_roomTypeManager.IsExist(roomType, hotel[choice].Id))
            {
                Console.WriteLine($"Room Type {roomType} already exists");
                Console.WriteLine("Unable to add room type");
                Console.WriteLine("Update Unsuccessfull");
                Read();
                return;
            }
            Console.Write("Enter price of room type: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter amount of room type: ");
            int amount = int.Parse(Console.ReadLine());
            RoomType type = new(hotel[choice].Id, roomType, amount, price);
            Console.WriteLine($"Enter room numbers of rooms under type {roomType}");
            for (int i = 1; i <= amount; i++)
            {
                string num = Console.ReadLine();
                _roomRepository.Add(new Room(type.Id, num));
            }
            _roomTypeRepository.Add(type);
            Console.WriteLine($"Room type {roomType} added successfully");
            Read();
        }

        private void RemoveRoomType()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Enter room type to remove: ");
            string roomType = Console.ReadLine();
            if (_roomTypeManager.IsExist(roomType, hotel[choice].Id))
            {
                if (_roomTypeRepository.Get(hotel[choice].Id, roomType).Status == Models.Enums.RoomTypeStatus.Available)
                {
                    Console.WriteLine($"Cannot remove room type {roomType} because it is being occupied!!!\nTry again later");
                    Read();
                    return;
                }
                List<Room> rooms = _roomRepository.GetByRoomTypeId(_roomTypeRepository.Get(hotel[choice].Id, roomType).Id);
                foreach (Room room in rooms)
                {
                    _roomRepository.Remove(room);
                }
                _roomTypeRepository.Remove(_roomTypeRepository.Get(hotel[choice].Id, roomType));
                Console.WriteLine($"Successfully removed room type {roomType}");
                Read();
            }
            else
            {
                Console.WriteLine($"Room Type {roomType} does not exists");
                Console.WriteLine("Unable to remove room type");
                Console.WriteLine("Update Unsuccessfull");
                Read();
            }
        }

        private void ChangePriceOfRoomType()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to update room prices (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Enter which room type price to change: ");
            string roomType = Console.ReadLine();
            if (_roomTypeManager.IsExist(roomType, hotel[choice].Id))
            {
                Console.Write("Enter new price: ");
                double price = double.Parse(Console.ReadLine());
                _roomTypeRepository.Get(hotel[choice].Id, roomType).Price = price;
                Console.WriteLine($"Price of {roomType} room type has been successfully changed to N{price:n}");
                Read();
            }
            else
            {
                Console.WriteLine($"Room Type {roomType} does not exists");
                Console.WriteLine("Unable to change price of unavailable room type");
                Console.WriteLine("Update Unsuccessfull");
                Read();
            }
        }

        private void ChangeAmount()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to update room amount (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Enter which room type amount to change: ");
            string roomType = Console.ReadLine();
            if (_roomTypeManager.IsExist(roomType, hotel[choice].Id))
            {
                RoomType type = _roomTypeRepository.Get(hotel[choice].Id, roomType);
                Console.Write("Enter new amount: ");
                int amount = int.Parse(Console.ReadLine());
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
                Console.WriteLine($"Amount of {roomType} room type has been successfully changed to {amount}");
                Read();
            }
            else
            {
                Console.WriteLine($"Room Type {roomType} does not exists");
                Console.WriteLine("Unable to change amount of unavailable room type");
                Console.WriteLine("Update Unsuccessfull");
                Read();
            }
        }

        private void AddRoom()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Under which room type is room to be added: ");
            string roomType = Console.ReadLine();
            if (_roomTypeManager.IsExist(roomType, hotel[choice].Id))
            {
                RoomType type = _roomTypeRepository.Get(hotel[choice].Id, roomType);
                Console.Write("Enter room number of room to be added: ");
                string num = Console.ReadLine();
                _roomRepository.Add(new Room(type.Id, num));
                Console.WriteLine("Room added successfully!!!");
                Read();
            }
            else
            {
                Console.WriteLine($"Room type {roomType} does not exist!!!");
                Read();
            }
        }

        private void RemoveRoom()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
                if (choice > hotel.Count)
                {
                    Console.WriteLine("Hotel does not exists");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Under which room type does room to be removed exists: ");
            string roomType = Console.ReadLine();
            if (_roomTypeManager.IsExist(roomType, hotel[choice].Id))
            {
                bool isContinue = true;
                while (isContinue)
                {
                    RoomType type = _roomTypeRepository.Get(hotel[choice].Id, roomType);
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
                            isContinue = false;
                            Read();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Room number {num} does not exist!!!Try again");
                        Read();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Room type {roomType} does not exist!!!");
                Read();
            }
        }

        private void UpdateRoomService()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("1. Add Room Service");
                Console.WriteLine("2. Remove Room Service");
                Console.WriteLine("3. Change price of existing Room Service");
                Console.WriteLine("0. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddRoomService();
                        break;
                    case 2:
                        RemoveRoomService();
                        break;
                    case 3:
                        ChangePriceOfRoomService();
                        break;
                    case 0:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }
            }
        }

        private void AddRoomService()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
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
                input = char.Parse(Console.ReadLine().ToUpper());
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
                    Console.Write($"{service}:  ");
                    double price = double.Parse(Console.ReadLine());
                    _roomServiceRepository.Add(new RoomService(hotel[choice].Id, service, price));
                }
                hotel[choice].RoomService = true;
                Console.WriteLine("Room service(s) has been added successfully!!!");
                Read();
            }
            else
            {
                Console.WriteLine("Your hotel is not providing room service");
                hotel[choice].RoomService = false;
                Read();
            }
        }

        private void RemoveRoomService()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
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
                Read();
            }
            else
            {
                Console.Write("Enter name of room service to be removed: ");
                string name = Console.ReadLine();
                if (_roomServiceManager.IsExist(name, hotel[choice].Id))
                {
                    _roomServiceRepository.Remove(_roomServiceRepository.GetByName(name, hotel[choice].Id));
                    Console.WriteLine($"{name} room service has been removed successfully!!!");
                    Read();
                }
                else
                {
                    Console.WriteLine($"No existing room service with name {name}!!!");
                    Read();
                }
            }
        }

        private void ChangePriceOfRoomService()
        {
            List<Hotel> hotel = _hotelRepository.GetList(Admin.LoggedInAdminId);
            int choice = 1;
            if (hotel.Count > 1)
            {
                Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
                choice = int.Parse(Console.ReadLine());
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
                Read();
            }
            else
            {
                Console.Write("Enter name of room service of price to be changed: ");
                string name = Console.ReadLine();
                if (_roomServiceManager.IsExist(name, hotel[choice].Id))
                {
                    Console.Write("Enter new price of room service: ");
                    double price = double.Parse(Console.ReadLine());
                    _roomServiceRepository.GetByName(name, hotel[choice].Id).Price = price;
                    Console.WriteLine($"{name} price has been successfully changed to N{price:n}");
                    Read();
                }
                else
                {
                    Console.WriteLine($"No existing room service with name {name}!!!");
                    Read();
                }
            }
        }

        private void RemoveHotel()
        {
            Console.WriteLine("All details about hotel will be removed including room types, room services, etc");
            Console.WriteLine("Are you sure you want to remove hotel (Y/N)");
            char choice = char.Parse(Console.ReadLine().ToUpper());
            if (choice != 'Y')
            {
                return;
            }
            Console.Write("Enter name of hotel to be removed: ");
            string name = Console.ReadLine();
            Hotel hotel = _hotelRepository.GetByName(name);
            if (hotel is null)
            {
                Console.WriteLine($"Hotel with name {name} does not exist!!!\nTry again later");
                Read();
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
                    List<RoomType> types = _roomTypeRepository.GetAll(hotel.Id);
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
                    Read();
                }
                else
                {
                    Console.WriteLine($"Hotel {name} is not registered under user's name and therefore cannot be removed by user!!!");
                    Read();
                }
            }
        }

        private void DeleteAccount()
        {
            Console.WriteLine("All details about user will be removed if user deletes account");
            Console.WriteLine("Do you want to continue with this operation (Y/N)");
            char choice = char.Parse(Console.ReadLine().ToUpper());
            if (choice == 'Y')
            {
                Admin admin = _adminRepository.GetById(Admin.LoggedInAdminId);
                if(admin is null)
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
                    List<RoomType> types = _roomTypeRepository.GetAll(hotel.Id);
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
        }
    }
}