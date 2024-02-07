using Project_TestCase2.Models.Entities;
using Project_TestCase2.Models.Extensions;
using Project_TestCase2.Repositories.Implementation;
using Project_TestCase2.Repositories.Interface;
using Project_TestCase2.Service.Implementation;
using Project_TestCase2.Service.Interface;

namespace Project_TestCase2.Menu
{
    public class CustomerMenu
    {
        private bool skip = false;
        private int views = 0;
        private Random random = new();
        private ConsoleColor[] colours = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow};
        IHotelManager _hotelManager = new HotelManager();
        IRoomManager _roomManager = new RoomManager();
        IRoomServiceManager _roomServiceManager = new RoomServiceManager();
        IRoomTypeManager _roomTypeManager = new RoomTypeManager();
        IManager<Customer> _customerManager = new CustomerManager();
        IStayManager _historyManager = new StayManager();
        IRepository<Hotel> _hotelRepository = new HotelRepository();
        IRepository<Customer> _customerRepository = new CustomerRepository();
        IRoomTypeRepository _roomTypeRepository = new RoomTypeRepository();
        IRoomServiceRepository _roomServiceRepository = new RoomServiceRepository();
        IRoomRepository _roomRepository = new RoomRepository();
        IStayRepository _historyRepository = new StayRepository();
        OnStart onStart = new();
        public void MainMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== CUSTOMER MENU ======");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");
                int choice = 3;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                Console.ForegroundColor = ConsoleColor.Red;
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

            Customer customer = new(firstName, lastname, email, password);
            _customerManager.Register(customer);
            Read();
        }

        private void Login()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            if (_customerManager.Login(email, password))
            {
                onStart.CustomerStatus();
                List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
                foreach (StayHistory history in histories)
                {
                    if (history.CustomerStatus == Models.Enums.CustomerStatus.CheckedOut)
                    {
                        CheckOut(history);
                    }
                }
                onStart.RoomStatus();
                Console.WriteLine("Login Successfull");
                Read();
                Menu();
                views--;
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
                if (views == 0)
                {
                    Customer customer = _customerRepository.GetById(Customer.LoggedInCustomerId);
                    Console.WriteLine($"Welcome {customer.FirstName.ToPascalCase()} {customer.LastName.ToPascalCase()}");
                    views++;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== MENU ======");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. View Available Hotels");
                Console.WriteLine("2. Book a Room");
                Console.WriteLine("3. Increase Stay Period");
                Console.WriteLine("4. Change Check-In time");
                Console.WriteLine("5. Room Service");
                Console.WriteLine("6. Check Room details");
                Console.WriteLine("7. Check Billings");
                Console.WriteLine("8. Rate Your Experience");
                Console.WriteLine("9. CheckOut");
                Console.WriteLine("10. Delete Account");
                Console.WriteLine("0. Logout");
                int choice = 11;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t====== VIEWING AVAILABLE HOTELS ======");
                        ViewAvailableHotels();
                        break;
                    case 2:
                        Console.WriteLine("\t====== BOOKING ROOM ======");
                        BookARoom();
                        break;
                    case 3:
                        Console.WriteLine("\t====== INCREASING STAY PERIOD ======");
                        IncreaseStayPeriod();
                        break;
                    case 4:
                        Console.WriteLine("\t====== CHANGING CHECK-IN TIME ======");
                        ChangeCheckInTime();
                        break;
                    case 5:
                        RoomService();
                        break;
                    case 6:
                        Console.WriteLine("\t====== VIEWING ROOM DETAILS ======");
                        ViewRoomDetails();
                        break;
                    case 7:
                        Console.WriteLine("\t====== VIEWING BILLS ======");
                        ViewBillings();
                        break;
                    case 8:
                        Console.WriteLine("\t====== RATING HOTEL ======");
                        RateHotel();
                        break;
                    case 9:
                        Console.WriteLine("\t====== CHECKING OUT ======");
                        CheckOut();
                        break;
                    case 10:
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

        private void ViewAvailableHotels()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotels = _hotelRepository.GetAll();
            if (hotels.Count == 0)
            {
                Console.WriteLine("No Available Hotel at the Moment!!!.\nTry again later");
            }
            else
            {
                int count = 0;
                Console.WriteLine("Viewing all hotels: ");
                foreach (var hotel in hotels)
                {
                    Console.WriteLine($"{++count}. {hotel.Name.ToPascalCase()}".PadRight(20) + $"{hotel.Ratings} star ratings");
                }
            }
            if (!skip)
            {
                Read();
            }
        }

        private void BookARoom()
        {
            skip = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            onStart.CheckRoomTypeStatus();
            List<Hotel> hotels = _hotelRepository.GetAll();
            if (hotels.Count == 0)
            {
                Console.WriteLine("No Available Hotel!!!Try again Later");
            }
            else
            {
                skip = true;
                ViewAvailableHotels();
                skip = false;
                Console.WriteLine("Choose Hotel to book from: ");
                string choice = Console.ReadLine();
                if (!_hotelManager.IsExist(choice))
                {
                    Console.WriteLine($"Hotel {choice.ToPascalCase()} does not exist!!!");
                    Read();
                    return;
                }
                Hotel hotel = _hotelRepository.GetByName(choice);
                _roomTypeManager.DisplayRoomTypes(hotel.Id);
                Console.WriteLine("Choose room type to book from: ");
                string room = Console.ReadLine();
                if (!_roomTypeManager.IsExist(room, hotel.Id))
                {
                    Console.WriteLine($"Room type {room.ToPascalCase()} does not exist!!!");
                    Read();
                    return;
                }
                RoomType type = _roomTypeRepository.Get(hotel.Id, room);
                if (type.Status == Models.Enums.RoomTypeStatus.Available)
                {
                    int date = 0;
                    bool roomService = false;
                    string service = "";
                    Console.Write("Do you want to check in immediately (Y/N): ");
                    char choice2 = '0';
                    while (choice2 == '0')
                    {
                        if (char.TryParse(Console.ReadLine().ToUpper(), out char num))
                        {
                            choice2 = num;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!!!");
                            Console.WriteLine("Try again");
                        }
                    }
                    if (choice2 != 'Y')
                    {
                        Console.Write("How days from now do you want to check in: ");
                        date = -1;
                        while (date < 0)
                        {
                            if (int.TryParse(Console.ReadLine(), out int num))
                            {
                                date = num;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input!!!");
                                Console.WriteLine("Try again");
                            }
                        }
                    }
                    Console.Write("How many nights are you staying for: ");
                    int nights = -1;
                    while (nights < 0)
                    {
                        if (int.TryParse(Console.ReadLine(), out int num))
                        {
                            nights = num;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!!!");
                            Console.WriteLine("Try again");
                        }
                    }
                    if (hotel.RoomService)
                    {
                        Console.WriteLine("Do you want hotel to provide you room service: ");
                        char choice3 = '0';
                        while (choice3 == '0')
                        {
                            if (char.TryParse(Console.ReadLine().ToUpper(), out char num))
                            {
                                choice3 = num;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input!!!");
                                Console.WriteLine("Try again");
                            }
                        }
                        if (choice3 == 'Y')
                        {
                            Console.WriteLine("Choose room service to be provided: ");
                            _roomServiceManager.DisplayRoomServices(hotel.Id);
                            service = Console.ReadLine();
                            if (_roomServiceManager.IsExist(service, hotel.Id))
                            {
                                roomService = true;
                            }
                            else
                            {
                                Console.WriteLine($"{service} room service does not exist!!!\n The hotel is not providing you room service");
                            }
                        }
                    }
                    Room room1 = _roomManager.GetRoom(type.Id);
                    if(room1 is null)
                    {
                        Console.WriteLine($"No available room under {type.Name} room type");
                        Read();
                        return;
                    }
                    Console.WriteLine($"Your room number is {room1.Number}");
                    if (choice2 == 'Y')
                    {
                        room1.RoomStatus = Models.Enums.RoomStatus.Occupied;
                    }
                    StayHistory history = new(hotel.Name, hotel.Id, type.Name, type.Id, type.Price, roomService, _roomServiceRepository.GetByName(service, hotel.Id), room1.Number, Customer.LoggedInCustomerId, nights, date);
                    _historyRepository.Add(history);
                }
                else
                {
                    Console.WriteLine($"No available rooms in room type {room}!!!");
                    Console.WriteLine($"Try booking a room in available room type or Try again later");
                }
                Read();
            }
        }

        private void IncreaseStayPeriod()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int choice = 1;
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            if (histories.Count == 0)
            {
                Console.WriteLine("Cannot increase stay period unless user has booked a room!!!");
                Read();
                return;
            }
            else if (histories.Count > 1)
            {
                Console.WriteLine("Choose which room to increase stay period: ");
                _historyManager.DisplayRooms(histories);
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
                if (choice > histories.Count)
                {
                    Console.WriteLine("Room does not exists!!!");
                    Read();
                    return;
                }
            }
            choice--;
            Console.WriteLine("Enter how many days you wish to increase stay period");
            int days = -1;
            while (days < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    days = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            histories[choice].StayPeriod += days;
            histories[choice].CheckOutDate = histories[choice].CheckInDate.AddDays(histories[choice].StayPeriod);
            histories[choice].TotalPriceOfStay = histories[choice].Price * histories[choice].StayPeriod;
            if (histories[choice].IsRoomService)
            {
                histories[choice].TotalPriceOfStay += histories[choice].RoomService.Price;
            }
            Console.WriteLine("Successfully increased stay period!!!");
            Read();
        }

        private void ChangeCheckInTime()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int choice = 1;
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            if (histories.Count == 0)
            {
                Console.WriteLine("Cannot change check-in time unless user has booked a room!!!");
                Read();
                return;
            }
            else if (histories.Count > 1)
            {
                Console.WriteLine("Choose which room to change check in time: ");
                _historyManager.DisplayRooms(histories);
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
                if (choice > histories.Count)
                {
                    Console.WriteLine("Room does not exists!!!");
                    Read();
                    return;
                }
            }
            choice--;
            if (DateTime.Now > histories[choice].CheckInDate)
            {
                Console.WriteLine("Cannot change check in time!!!");
                Console.WriteLine("Can only be changed if user hasn't been checked in");
            }
            else
            {
                Console.Write("How many days from now do you wish to be checked in: ");
                int days = -1;
                while (days < 0)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        days = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!!!");
                        Console.WriteLine("Try again");
                    }
                }
                histories[choice].CheckInDate = DateTime.Now.AddDays(days);
                histories[choice].CheckOutDate = histories[choice].CheckInDate.AddDays(histories[choice].StayPeriod);
                Console.WriteLine($"Check in date has successfully been changed to {histories[choice].CheckInDate.ToString("dddd, MMMM dd, yyyy")}");
                Read();
            }
        }

        private void RoomService()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t====== ROOM SERVICE MENU ======");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Opt-in/out of Room Service");
                Console.WriteLine("2. Change type of room service being provided");
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
                        Console.WriteLine("\t====== CHANGING ROOM SERVICE STATUS ======");
                        OptInOrOutOfRoomService();
                        break;
                    case 2:
                        Console.WriteLine("\t====== CHANGING ROOM SERVICE TYPE ======");
                        ChangeRoomServiceType();
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

        private void OptInOrOutOfRoomService()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int choice = 1;
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            if (histories.Count == 0)
            {
                Console.WriteLine("Cannot opt in/out of room service unless user has booked a room!!!");
                Read();
                return;
            }
            else if (histories.Count > 1)
            {
                Console.WriteLine("Choose which room to opt in/out of room service: ");
                _historyManager.DisplayRooms(histories);
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
                if (choice > histories.Count)
                {
                    Console.WriteLine("Room does not exists!!!");
                    Read();
                    return;
                }
            }
            choice--;
            if(!_hotelRepository.GetById(histories[choice].HotelId).RoomService)
            {
                Console.WriteLine("Hotel is not providing room service!!!");
                Console.WriteLine("Cannot opt in to Room Service function!!!");
                Read();
                return;
            }
            if (histories[choice].IsRoomService)
            {
                Console.WriteLine("Are you  sure you want to opt out of the room service function? (Y/N)");
                char input = '0';
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
                if (input == 'Y')
                {
                    histories[choice].IsRoomService = false;
                    histories[choice].RoomService = null;
                    Console.WriteLine("You have opted out of the room service function!!!");
                }
            }
            else
            {
                Console.WriteLine("Are you  sure you want to opt in to the room service function? (Y/N)");
                char input = '0';
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
                if (input == 'Y')
                {
                    Console.WriteLine("Choose room service to be provided: ");
                    _roomServiceManager.DisplayRoomServices(histories[choice].HotelId);
                    string service = Console.ReadLine();
                    if (_roomServiceManager.IsExist(service, histories[choice].HotelId))
                    {
                        histories[choice].IsRoomService = true;
                        histories[choice].RoomService = _roomServiceRepository.GetByName(service, histories[choice].HotelId);
                        Console.WriteLine("You have opted in to the room service function!!!");
                    }
                    else
                    {
                        Console.WriteLine($"{service} room service does not exist!!!\n The hotel is not providing you room service");
                    }
                }
                histories[choice].TotalPriceOfStay = histories[choice].Price * histories[choice].StayPeriod;
                if (histories[choice].IsRoomService)
                {
                    histories[choice].TotalPriceOfStay += histories[choice].RoomService.Price;
                }
                Read();
            }
        }

        private void ChangeRoomServiceType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int choice = 1;
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            if (histories.Count == 0)
            {
                Console.WriteLine("Cannot change room service type unless user has booked a room!!!");
                Read();
                return;
            }
            else if (histories.Count > 1)
            {
                Console.WriteLine("Choose which room to change room service type: ");
                _historyManager.DisplayRooms(histories);
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
                if (choice > histories.Count)
                {
                    Console.WriteLine("Room does not exists!!!");
                    Read();
                    return;
                }
            }
            choice--;
            if (histories[choice].IsRoomService)
            {
                Console.WriteLine("Choose room service to be provided: ");
                _roomServiceManager.DisplayRoomServices(histories[choice].HotelId);
                string service = Console.ReadLine();
                if (_roomServiceManager.IsExist(service, histories[choice].HotelId))
                {
                    histories[choice].IsRoomService = true;
                    histories[choice].RoomService = _roomServiceRepository.GetByName(service, histories[choice].HotelId);
                    Console.WriteLine($"You have successfully changed room service type to {service}!!!");
                }
                else
                {
                    Console.WriteLine($"{service} room service does not exist!!!\nRoom service type remains unchanged");
                }
            }
            else
            {
                Console.WriteLine("Cannot change room service type!!!\nHotel must be providing user room service in order to change type");
            }
            histories[choice].TotalPriceOfStay = histories[choice].Price * histories[choice].StayPeriod;
            if (histories[choice].IsRoomService)
            {
                histories[choice].TotalPriceOfStay += histories[choice].RoomService.Price;
            }
            Read();
        }

        private void ViewRoomDetails()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int choice = 1;
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            if (histories.Count == 0)
            {
                Console.WriteLine("Cannot view room details unless user has booked a room!!!");
                Read();
                return;
            }
            else if (histories.Count > 1)
            {
                Console.WriteLine("Choose which room to check details: ");
                _historyManager.DisplayRooms(histories);
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
                if (choice > histories.Count)
                {
                    Console.WriteLine("Room does not exists!!!");
                    Read();
                    return;
                }
            }
            choice--;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Hotel Name: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(histories[choice].Hotel);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Room Type: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(histories[choice].RoomType);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Room Number: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(histories[choice].RoomNumber);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Has Room Service: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(histories[choice].IsRoomService);
            if (histories[choice].IsRoomService)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Name of Room Service: ");
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine(histories[choice].RoomService.Name);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Check-in Time: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(histories[choice].CheckInDate.ToString("dddd, MMMM dd, yyyy"));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Time to be checked-out: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(histories[choice].CheckOutDate.ToString("dddd, MMMM dd, yyyy"));
            Console.ForegroundColor = ConsoleColor.Gray;
            Read();
        }

        private void ViewBillings()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int choice = 1;
            List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
            if (histories.Count == 0)
            {
                Console.WriteLine("Cannot check billings unless user has booked a room!!!");
                Read();
                return;
            }
            else if (histories.Count > 1)
            {
                Console.WriteLine("Choose which room to check billings: ");
                _historyManager.DisplayRooms(histories);
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
                if (choice > histories.Count)
                {
                    Console.WriteLine("Room does not exists!!!");
                    Read();
                    return;
                }
            }
            choice--;
            Console.Write("Price of room per night: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine($"N{histories[choice].Price:n}");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (histories[choice].IsRoomService)
            {
                Console.Write("Price of room service: ");
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine($"N{histories[choice].RoomService.Price:n}");
                Console.ForegroundColor = ConsoleColor.Gray;
                histories[choice].TotalPriceOfStay = histories[choice].RoomService.Price;
            }
            double price = histories[choice].Price * histories[choice].StayPeriod;
            histories[choice].TotalPriceOfStay += price;
            Console.Write("Total price of stay: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine($"N{histories[choice].TotalPriceOfStay:n}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Read();
        }

        private void RateHotel()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int choice = 1;
            List<StayHistory> histories = _historyRepository.GetHotels(Customer.LoggedInCustomerId);
            if (histories.Count == 0)
            {
                Console.WriteLine("Cannot rate experience unless user has booked a room!!!");
                Read();
                return;
            }
            else if (histories.Count > 1)
            {
                Console.WriteLine("Choose which hotel to be rated: ");
                _historyManager.DisplayHotels(histories);
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
                if (choice > histories.Count)
                {
                    Console.WriteLine("Hotel does not exists!!!");
                    Read();
                    return;
                }
            }
            choice--;
            Console.WriteLine("Rate your satisfaction from 1-5");
            int rating = -1;
            while (rating < 0)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    rating = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            _hotelRepository.GetById(histories[choice].HotelId).Ratings = (_hotelRepository.GetById(histories[choice].HotelId).Ratings + rating) / 2;
            foreach (StayHistory history in _historyRepository.GetAllHotels(Customer.LoggedInCustomerId, histories[choice].HotelId))
            {
                history.Rate = true;
            }
            Console.WriteLine("Thanks for your time");
            Read();
        }

        private void CheckOut()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Early Check out will incur extra fees");
            Console.WriteLine("Are you sure you want to continue with this operation (Y/N)");
            int choice2 = '0';
            while (choice2 == '0')
            {
                if (char.TryParse(Console.ReadLine().ToUpper(), out char num))
                {
                    choice2 = num;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }
            if (choice2 == 'Y')
            {
                int choice = 1;
                List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
                if (histories.Count == 0)
                {
                    Console.WriteLine("Cannot check out unless user has booked a room!!!");
                    Read();
                    return;
                }
                else if (histories.Count > 1)
                {
                    Console.WriteLine("Choose which room to be checked out of: ");
                    _historyManager.DisplayRooms(histories);
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
                    if (choice > histories.Count)
                    {
                        Console.WriteLine("Room does not exists!!!");
                        Read();
                        return;
                    }
                }
                choice--;
                if (!histories[choice].Rate)
                {
                    Console.WriteLine("Kindly please rate your satisfaction from 1-5");
                    int rating = -1;
                    while (rating < 0)
                    {
                        if (int.TryParse(Console.ReadLine(), out int num))
                        {
                            rating = num;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!!!");
                            Console.WriteLine("Try again");
                        }
                    }
                    _hotelRepository.GetById(histories[choice].HotelId).Ratings = (_hotelRepository.GetById(histories[choice].HotelId).Ratings + rating) / 2;
                    foreach (StayHistory history in _historyRepository.GetAllHotels(Customer.LoggedInCustomerId, histories[choice].HotelId))
                    {
                        history.Rate = true;
                    }
                }
                histories[choice].TotalPriceOfStay += _hotelRepository.GetById(histories[choice].HotelId).EarlyCheckOutFee;
                Console.WriteLine($"Total fee to be paid is N{histories[choice].TotalPriceOfStay:n}");
                _roomRepository.GetByRoomNumber(histories[choice].RoomNumber, histories[choice].RoomTypeId).RoomStatus = Models.Enums.RoomStatus.Vacant;
                _historyRepository.Remove(histories[choice]);
                Console.WriteLine("Successfully Checked-Out");
                Read();
            }
        }

        private void CheckOut(StayHistory history)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Check out time has passed!!!");
            Console.WriteLine("Checking Out...");
            Console.WriteLine($"Total fee to be paid is N{history.TotalPriceOfStay:n}");
            _roomRepository.GetByRoomNumber(history.RoomNumber, history.RoomTypeId).RoomStatus = Models.Enums.RoomStatus.Vacant;
            _historyRepository.Remove(history);
            Console.WriteLine("Successfully Checked-Out");
            Read();
        }

        private void DeleteAccount()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("All details about user will be removed if user deletes account");
            Console.WriteLine("Do you want to continue with this operation (Y/N)");
            char choice = '0';
            while (choice == '0')
            {
                if (char.TryParse(Console.ReadLine(), out char num))
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
                Customer customer = _customerRepository.GetById(Customer.LoggedInCustomerId);
                if (customer is null)
                {
                    Console.WriteLine("Account not found!!! \nAccount must be registered in order to delete account");
                    Read();
                    return;
                }
                List<StayHistory> histories = _historyRepository.Get(Customer.LoggedInCustomerId);
                foreach (StayHistory history in histories)
                {
                    if (history.CustomerStatus == Models.Enums.CustomerStatus.CheckedIn)
                    {
                        Console.WriteLine("User is Checked-In and therefore cannot delete account!!!\nTry again later");
                        Read();
                        return;
                    }
                }
                foreach (StayHistory history in histories)
                {
                    _historyRepository.Remove(history);
                }
                _customerRepository.Remove(customer);
                Console.WriteLine("Successfully deleted account!!!");
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