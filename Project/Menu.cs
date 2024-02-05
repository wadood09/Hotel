public class Menu
{
    private bool skip = false;
    IHotelManager _hotelManager = new HotelManager();
    IManager<Admin> _adminManager = new AdminManager();
    IManager<Customer> _customerManager = new CustomerManager();
    IManager<StayHistory> _stayManager = new StayManager();
    public void MainMenu()
    {
        bool isContinue = true;
        Console.WriteLine("WELCOME");
        while (isContinue)
        {
            Console.WriteLine("1. ADMIN");
            Console.WriteLine("2. CUSTOMER");
            Console.WriteLine("0. EXIT");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AdminMainMenu();
                    break;
                case 2:
                    CustomerMainMenu();
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

    private void AdminMainMenu()
    {
        bool isContinue = true;
        while (isContinue)
        {

            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    LoginAdmin();
                    break;
                case 2:
                    RegisterAdmin();
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

    private void AdminMenu()
    {
        var loggedInAdmin = _adminManager.Get(Admin.LoggedInAdminId);
        Console.WriteLine($"\t Welcome {loggedInAdmin.FirstName.ToPascalCase()} {loggedInAdmin.LastName.ToPascalCase()}");
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

    private void RegisterAdmin()
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        string lastname = Console.ReadLine();

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        Admin admin = new Admin(firstName, lastname, email, password);
        _adminManager.Add(admin);
        Read();
    }

    private void LoginAdmin()
    {
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        if (_adminManager.Login(email, password))
        {
            Console.WriteLine("Login Successfull");
            Read();
            AdminMenu();
        }
        else
        {
            Console.WriteLine("Invalid Login Details");
            Read();
        }
    }

    private void RegisterHotel()
    {
        Console.Write("Enter name of hotel: ");
        string name = Console.ReadLine().ToUpper();
        Console.WriteLine("Enter types of rooms in hotel: ");
        List<string> roomTypes = new();
        List<RoomStatus> roomStatuses = new List<RoomStatus>();
        string input;
        while ((input = Console.ReadLine()) != "")
        {
            roomTypes.Add(input.ToPascalCase());
            roomStatuses.Add(RoomStatus.Vacant);
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
        Console.Write("Enter starting number of room number to be assigned: ");
        int startingNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Do you want your hotel to provide room service? (Y/N)");
        double roomServicePrice = 0;
        bool roomService = false;
        char choice = char.Parse(Console.ReadLine().ToUpper());
        if (choice == 'Y')
        {
            Console.Write("Enter price of room service: ");
            roomServicePrice = double.Parse(Console.ReadLine());
            roomService = true;
        }
        Hotel hotel = new Hotel(name, roomTypes, roomStatuses, roomPrices, roomAmount, startingNumber, roomService, roomServicePrice, Admin.LoggedInAdminId);
        hotel.RoomNumber = GenerateRoomNumbers(hotel, startingNumber);
        _hotelManager.AddHotel(hotel);
        Read();
    }

    private void ViewHotelDetails()
    {
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        if (hotel.Count == 0)
        {
            Console.WriteLine("Cannot view hotel details until hotel has been registered by user!!!");
            Read();
            return;
        }
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\t{hotel[choice].Name}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("ROOM TYPES".PadRight(10) + "ROOM STATUS".PadRight(20) + "AMOUNT OF ROOM".PadRight(300) + "PRICES OF ROOMS");
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i < hotel[choice].RoomTypes.Count; i++)
        {
            Console.WriteLine(hotel[choice].RoomTypes[i].PadRight(10) + hotel[choice].RoomStatuses[i].ToString().PadRight(20) + hotel[choice].AmountOfRoomsTypes[i].ToString().PadRight(30) + $"N{hotel[choice].RoomPrices[i]:n}");
        }
        Read();
    }

    private void UpdateHotelDetails()
    {
        List<Hotel> hotels = _hotelManager.Get(Admin.LoggedInAdminId);
        if(hotels.Count == 0)
        {
            Console.WriteLine("Cannot update hotel details until hotel has been registered by user!!!");
            Read();
            return;
        }
        bool isContinue = true;
        while (isContinue)
        {
            Console.WriteLine("1. Hotel Name");
            Console.WriteLine("2. Room Types");
            Console.WriteLine("3. Room Prices");
            Console.WriteLine("4. Room Amount");
            Console.WriteLine("5. Room Service");
            Console.WriteLine("6. Exit");
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
                    UpdateRoomPrices();
                    break;
                case 4:
                    UpdateRoomAmount();
                    break;
                case 5:
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
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to change name (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        Console.Write("Enter new hotel name: ");
        string hotelName = Console.ReadLine().ToUpper();
        if (_hotelManager.HotelNameExists(hotelName))
        {
            Console.WriteLine($"Hotel with name {hotelName} already exists");
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
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to add room type (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        Console.Write("Enter room type to add: ");
        string roomType = Console.ReadLine().ToPascalCase();
        foreach (string type in hotel[choice].RoomTypes)
        {
            if (roomType.ToLower() == type.ToLower())
            {
                Console.WriteLine($"Room Type {roomType} already exists");
                Console.WriteLine("Unable to add room type");
                Console.WriteLine("Update Unsuccessfull");
                Read();
                return;
            }
        }
        hotel[choice].RoomTypes.Add(roomType);
        Console.WriteLine($"Room type {roomType} added successfully");
        Read();
    }

    private void RemoveRoomType()
    {
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to remove room type (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        Console.Write("Enter room type to remove: ");
        string roomType = Console.ReadLine();
        bool IsExist = false;
        int index = 0;
        foreach (string type in hotel[choice].RoomTypes)
        {
            if (roomType.ToLower() == type.ToLower())
            {
                IsExist = true;
                index++;
                break;
            }
        }
        if (IsExist)
        {
            if (hotel[choice].RoomStatuses[index] == RoomStatus.Occupied)
            {
                Console.WriteLine($"Cannot remove room type {roomType} because it is being occupied!!!\nTry again later");
                Read();
                return;
            }
            hotel[choice].RoomTypes.Remove(roomType);
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

    private void UpdateRoomPrices()
    {
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to update room prices (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        Console.Write("Enter which room type price to change: ");
        string roomType = Console.ReadLine();
        int count = 0;
        bool IsExist = false;
        foreach (string type in hotel[choice].RoomTypes)
        {
            if (roomType.ToLower() == type.ToLower())
            {
                count++;
                IsExist = true;
                break;
            }
        }
        if (IsExist)
        {
            Console.Write("Enter new price: ");
            double price = double.Parse(Console.ReadLine());
            hotel[choice].RoomPrices[count] = price;
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

    private void UpdateRoomAmount()
    {
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to update room amount (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        Console.Write("Enter which room type amount to change: ");
        string roomType = Console.ReadLine();
        int count = 0;
        bool IsExist = false;
        foreach (string type in hotel[choice].RoomTypes)
        {
            if (roomType.ToLower() == type.ToLower())
            {
                count++;
                IsExist = true;
                break;
            }
        }
        if (IsExist)
        {
            Console.Write("Enter new amount: ");
            int amount = int.Parse(Console.ReadLine());
            hotel[choice].AmountOfRoomsTypes[count] = amount;
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

    private void UpdateRoomService()
    {
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        Console.WriteLine("Do you want hotel to provide room service? (Y/N)");
        bool roomService = false;
        char choice2 = char.Parse(Console.ReadLine().ToUpper());
        if (choice2 == 'Y')
        {
            roomService = true;
            hotel[choice].RoomService = roomService;
            Console.WriteLine("Your hotel is providing room service");
            Console.WriteLine("Do you want to change price of room service? (Y/N)");
            char choice3 = char.Parse(Console.ReadLine().ToUpper());
            if (choice3 == 'Y')
            {
                Console.Write("Enter new price of room service: ");
                double price = double.Parse(Console.ReadLine());
                hotel[choice].RoomServicePrice = price;
                Console.WriteLine($"Successfully changed room service price to N{price:n}");
            }
            Read();
        }
        else
        {
            hotel[choice].RoomService = roomService;
            Console.WriteLine("Your hotel is no longer providing room service");
            Read();
        }
    }

    private void RemoveHotel()
    {
        List<Hotel> hotel = _hotelManager.Get(Admin.LoggedInAdminId);
        int choice = 0;
        if (hotel.Count > 1)
        {
            Console.WriteLine("Enter the which hotel to view details (i.e enter 1,2,3,...)");
            choice = int.Parse(Console.ReadLine());
            if (choice >= hotel.Count)
            {
                Console.WriteLine("Hotel does not exists");
                Read();
                return;
            }
        }
        _hotelManager.RemoveHotel(hotel[choice]);
        Console.WriteLine("Hotel Successfully Removed");
        Read();
    }

    private void DeleteAccount()
    {
        Console.WriteLine("All details about user will be removed if user deletes account");
        Console.WriteLine("Do you want to continue with this operation (Y/N)");
        char choice = char.Parse(Console.ReadLine());
        if (char.ToUpper(choice) == 'Y')
        {
            Admin admin = _adminManager.Get(Admin.LoggedInAdminId);
            List<Hotel> hotels = _hotelManager.Get(admin.ID);
            foreach (Hotel hotel in hotels)
            {
                _hotelManager.RemoveHotel(hotel);
            }
            _adminManager.DeleteDetails(admin);
            MainMenu();
        }
        else
        {
            AdminMenu();
        }
    }

    private void CustomerMainMenu()
    {
        bool isContinue = true;
        while (isContinue)
        {

            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    LoginCustomer();
                    break;
                case 2:
                    RegisterCustomer();
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

    private void RegisterCustomer()
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastname = Console.ReadLine();

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        Customer customer = new Customer(firstName, lastname, email, password);
        _customerManager.Add(customer);
        Read();
    }

    private void LoginCustomer()
    {
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        if (_customerManager.Login(email, password))
        {
            StayHistory history = _stayManager.Get(Customer.LoggedInCustomerId);
            if (history != null)
            {
                if (history.CheckOutDate >= DateTime.Now)
                {
                    skip = true;
                    CheckOut();
                }
                skip = false;
            }
            Console.WriteLine("Login Successfull");
            Read();
            CustomerMenu();
        }
        else
        {
            Console.WriteLine("Invalid Login Details");
            Read();
        }
    }

    private void CustomerMenu()
    {
        var loggedInCustomer = _customerManager.Get(Customer.LoggedInCustomerId);
        Console.WriteLine($"\t Welcome {loggedInCustomer.FirstName.ToPascalCase()} {loggedInCustomer.LastName.ToPascalCase()}");
        bool isContinue = true;
        while (isContinue)
        {
            Console.WriteLine("1. View Available Hotels");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. Increase Stay Period");
            Console.WriteLine("4. Check Stay details");
            Console.WriteLine("5. Check Billings");
            Console.WriteLine("6. Rate Your Experience");
            Console.WriteLine("7. CheckOut");
            Console.WriteLine("0. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ViewAvailableHotels();
                    break;
                case 2:
                    BookARoom();
                    break;
                case 3:
                    IncreaseStayPeriod();
                    break;
                case 4:
                    GetStayDetails();
                    break;
                case 5:
                    GetBills();
                    break;
                case 6:
                    RateExperience();
                    break;
                case 7:
                    CheckOut();
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

    private void ViewAvailableHotels()
    {
        List<Hotel> hotels = _hotelManager.GetAll();
        if (hotels.Count == 0)
        {
            Console.WriteLine("No Available Hotel at the Moment!!!.\nTry again later");
            Read();
        }
        else
        {
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"{hotel.ID}. {hotel.Name} {hotel.Ratings} star ratings");
                Read();
            }
        }
    }

    private void BookARoom()
    {
        List<Hotel> hotels = _hotelManager.GetAll();
        Customer loggedInCustomer = _customerManager.Get(Customer.LoggedInCustomerId);
        if (hotels.Count == 0)
        {
            Console.WriteLine("No Available Hotel!!!Try again Later");
            Read();
            return;
        }
        else
        {
            Console.WriteLine("Choose Hotel to book from: ");
            ViewAvailableHotels();
            int choice = int.Parse(Console.ReadLine());
            Hotel hotel = _hotelManager.GetHotel(choice);
            GetRoomTypes(hotel);
            int room = int.Parse(Console.ReadLine());
            if (hotel.AmountOfRoomsTypes[room] == 0)
            {
                Console.WriteLine($"No available room of type {hotel.RoomTypes[room]}!!!.Try again later");
                Read();
                return;
            }
            hotel.RoomStatuses[room] = RoomStatus.Occupied;
            hotel.AmountOfRoomsTypes[room]--;
            Console.Write("How many nights are you staying for? : ");
            int nights = int.Parse(Console.ReadLine());
            loggedInCustomer.TotalPriceOfStay = (decimal)hotel.RoomPrices[room] * nights;
            char input;
            bool roomService = false;
            if (hotel.RoomService)
            {
                Console.WriteLine($"Room Service price is N{hotel.RoomServicePrice:n}");
                Console.Write("Do you want hotel to provide you room services (Y/N): ");
                input = char.Parse(Console.ReadLine().ToUpper());
                if (char.ToUpper(input) == 'Y')
                {
                    roomService = true;
                    loggedInCustomer.TotalPriceOfStay += (decimal)hotel.RoomServicePrice;
                }
            }
            Console.WriteLine($"Your room number is {hotel.RoomNumber[0]}");
            StayHistory history = new StayHistory(hotel.Name, choice, hotel.RoomTypes[room], room, roomService, hotel.RoomNumber[0], loggedInCustomer.ID, nights);
            _stayManager.Add(history);
            hotel.RoomNumber.RemoveAt(0);
            Read();
        }
    }

    private void IncreaseStayPeriod()
    {
        StayHistory history = _stayManager.Get(Customer.LoggedInCustomerId);
        if(history is null)
        {
            Console.WriteLine("Cannot increase stay period unless user has booked a room!!!");
            Read();
            return;
        }
        Console.WriteLine("Enter how many days you wish to increase stay period");
        int days = int.Parse(Console.ReadLine());
        history.StayPeriod += days;
        TimeSpan time = new TimeSpan(history.StayPeriod, 0, 0, 0, 0);
        history.CheckOutDate = history.CheckInDate.Add(time);
        history.Rate = true;
        Console.WriteLine("Stay has been increased");
    }

    private void GetStayDetails()
    {
        StayHistory history = _stayManager.Get(Customer.LoggedInCustomerId);
        if (history == null)
        {
            Console.WriteLine("Information Unavailable!!!\nKindly Please Book a Room To View Stay Details");
            Read();
            return;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Hotel Name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(history.Hotel);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Room Type: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(history.RoomType);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Room Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(history.RoomNumber);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Has Room Service: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(history.RoomService);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Check-in Time: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(history.CheckInDate.ToString("dddd MMM,dd,yyy"));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Time to be checked-out: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(history.CheckOutDate.ToString("dddd MMM,dd,yyy"));
            Console.ForegroundColor = ConsoleColor.Gray;
            Read();
        }
    }

    private void GetBills()
    {
        Customer customer = _customerManager.Get(Customer.LoggedInCustomerId);
        StayHistory history = _stayManager.Get(customer.ID);
        if(history is null)
        {
            Console.WriteLine("Cannot check bills unless user has booked a room!!!");
            Read();
            return;
        }
        Hotel hotel = _hotelManager.GetHotel(history.HotelID);
        Console.WriteLine($"Price of {hotel.RoomTypes[history.RoomID]} per night: N{hotel.RoomPrices[history.RoomID]:n}");
        if (history.RoomService)
        {
            Console.WriteLine($"Price of Room Service: N{hotel.RoomServicePrice:n}");
        }
        Console.Write($"Total price of stay: ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"N{customer.TotalPriceOfStay:n}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Read();
    }

    private void RateExperience()
    {
        StayHistory history = _stayManager.Get(Customer.LoggedInCustomerId);
        if(history is null)
        {
            Console.WriteLine("Cannot rate experience unless user has booked a room!!!");
            Read();
            return;
        }
        Hotel hotel = _hotelManager.GetHotel(history.HotelID);
        Console.WriteLine("Rate your satisfaction from 1-10");
        int rating = int.Parse(Console.ReadLine());
        hotel.Ratings = (hotel.Ratings + rating) / 2;
        Console.WriteLine("Thanks for your time");
        Read();
    }

    private void CheckOut()
    {
        char choice = 'Y';
        if (skip == false)
        {
            Console.WriteLine("All details about user will be removed if user checks out");
            Console.WriteLine("Do you want to continue with this operation (Y/N)");
            choice = char.Parse(Console.ReadLine());
        }
        if (char.ToUpper(choice) == 'Y')
        {
            StayHistory history = _stayManager.Get(Customer.LoggedInCustomerId);
            if(history is null)
            {
                Console.WriteLine("Cannot CheckOut user because user has not checked-in!!!");
                Read();
                return;
            }
            Hotel hotel = _hotelManager.GetHotel(history.HotelID);
            if (!history.Rate)
            {
                Console.WriteLine("Kindly please rate your satisfaction from 1-10");
                int rating = int.Parse(Console.ReadLine());
                hotel.Ratings = (hotel.Ratings + rating) / 2;
                Console.WriteLine("Thanks for your time");
            }
            hotel.RoomStatuses[history.RoomID] = RoomStatus.Vacant;
            hotel.AmountOfRoomsTypes[history.RoomID]++;
            hotel.RoomNumber.Add(history.RoomNumber);
            Customer customer = _customerManager.Get(Customer.LoggedInCustomerId);
            _stayManager.DeleteDetails(history);
            _customerManager.DeleteDetails(customer);
            MainMenu();
        }
        else
        {
            CustomerMenu();
        }
    }

    private List<int> GenerateRoomNumbers(Hotel hotel, int starting)
    {
        List<int> roomNumber = new();
        int total = GetTotalAmountOfRooms(hotel);
        for (int i = 0; i < total; i++)
        {
            roomNumber.Add(starting + i);
        }
        return roomNumber;
    }

    private void GetRoomTypes(Hotel hotel)
    {
        int count = 0;
        Console.WriteLine("Choose Room Type");
        foreach (var room in hotel.RoomTypes)
        {
            Console.WriteLine($"{++count}.  {room}  N{hotel.RoomPrices[count - 1]:n} per night");
        }
    }

    private int GetTotalAmountOfRooms(Hotel hotel)
    {
        int total = 0;
        foreach (int num in hotel.AmountOfRoomsTypes)
        {
            total += num;
        }
        return total;
    }

    private void Read()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}