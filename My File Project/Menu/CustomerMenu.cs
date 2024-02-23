using My_File_Project.Entities;
using My_File_Project.Models.Entities;
using My_File_Project.Models.Enums;
using My_File_Project.Models.Extensions;
using My_File_Project.Services.Implementation;
using My_File_Project.Services.Interface;

namespace My_File_Project.Menu
{
    public class CustomerMenu
    {
        private bool skip = false;
        private bool view = true;
        private Random random = new();
        private ConsoleColor[] colours = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow };
        IAdminService _adminService = new AdminService();
        IBookingService _bookingService = new BookingService();
        ICustomerService _customerService = new CustomerService();
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
                if (view)
                {
                    User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER")!;
                    Console.WriteLine($"Welcome {user.FirstName!.ToPascalCase()} {user.LastName!.ToPascalCase()}");
                    view = false;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine("\t========== MENU ==========");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. View Available Hotels");
                Console.WriteLine("2. Fund Wallet");
                Console.WriteLine("3. Check Wallet Balance");
                Console.WriteLine("4. Book a Room");
                Console.WriteLine("5. Increase Stay Period");
                Console.WriteLine("6. Change Check-In time");
                Console.WriteLine("7. Room Service");
                Console.WriteLine("8. Check Room details");
                Console.WriteLine("9. Check Billings");
                Console.WriteLine("10. Rate Your Experience");
                Console.WriteLine("11. CheckOut");
                Console.WriteLine("12. Delete Account");
                Console.WriteLine("0. Logout");
                int choice = 13;
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    choice = num;
                }
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t========== VIEWING AVAILABLE HOTELS ==========");
                        ViewAvailableHotels();
                        break;
                    case 2:
                        Console.WriteLine("\t========== FUNDING WALLET ==========");
                        FundWallet();
                        break;
                    case 3:
                        Console.WriteLine("\t========== CHECKING WALLET BALANCE ==========");
                        generalMenu.CheckBalance("CUSTOMER");
                        Read();
                        break;
                    case 4:
                        Console.WriteLine("\t========== BOOKING ROOM ==========");
                        BookARoom();
                        break;
                    case 5:
                        Console.WriteLine("\t========== INCREASING STAY PERIOD ==========");
                        IncreaseStayPeriod();
                        break;
                    case 6:
                        Console.WriteLine("\t========== CHANGING CHECK-IN TIME ==========");
                        ChangeCheckInTime();
                        break;
                    case 7:
                        RoomService();
                        break;
                    case 8:
                        Console.WriteLine("\t========== VIEWING ROOM DETAILS ==========");
                        ViewRoomDetails();
                        break;
                    case 9:
                        Console.WriteLine("\t========== VIEWING BILLS ==========");
                        ViewBillings();
                        break;
                    case 10:
                        Console.WriteLine("\t========== RATING HOTEL ==========");
                        RateHotel();
                        break;
                    case 11:
                        Console.WriteLine("\t========== CHECKING OUT ==========");
                        CheckOut();
                        break;
                    case 12:
                        Console.WriteLine("\t========== DELETING ACCOUNT ==========");
                        DeleteAccount();
                        break;
                    case 0:
                        view = true;
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
            List<Hotel> hotels = _hotelService.GetAll();
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
                    Console.WriteLine($"{++count}. {hotel.Name!}".PadRight(20) + $"{hotel.Ratings} star ratings");
                }
            }
            if (!skip)
            {
                Read();
            }
        }

        private void FundWallet()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            User? user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER");
            if (user is null)
            {
                Console.WriteLine("User must be registered in order to deposit wallet!!!");
                Read();
                return;
            }
            Console.Write("Enter amount to be deposited: ");
            double amount = new();
            generalMenu.EnterChoice(ref amount);
            user!.Wallet += (decimal)amount;
            Console.WriteLine($"You have successfully deposited N{amount:n} into your account!!!");
            _userService.UpdateFile();
            Read();
        }

        private void BookARoom()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Hotel> hotels = _hotelService.GetAll();
            if (hotels.Count == 0)
            {
                Console.WriteLine("No Available Hotel!!!Try again Later");
            }
            else
            {
                User? user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER");
                if (user is null)
                {
                    Console.WriteLine("User must be registered in order to book room!!!");
                    Read();
                    return;
                }
                else
                {
                    if (user.Wallet == 0)
                    {
                        Console.WriteLine("Account must be deposited before user can book a room!!!");
                        Read();
                        return;
                    }
                }
                HotelSection(out Hotel? hotel);
                if (hotel is null)
                {
                    return;
                }

                RoomTypeSection(out RoomType? type, hotel.Id);
                if (type is null)
                {
                    return;
                }
                generalMenu.CheckRoomStatus(type.Id);

                char choice = new();
                RoomSection(out int nights, out DatePeriod period, out Room? room, type.Id, ref choice);
                if (room is null)
                {
                    return;
                }


                RoomService? roomService = new();
                bool hasRoomService = false;
                if (hotel.HasRoomService)
                {
                    RoomServiceSection(ref roomService, ref hasRoomService, hotel.Id);
                }

                CheckWallet(type.Id, nights, roomService, out double price);
                if (price == 0)
                {
                    Console.WriteLine("Consider increasing wallet balance before booking a room");
                    Read();
                    return;
                }
                else
                {
                    CreditWallet(hotel.Id, price);
                }

                Console.WriteLine($"Your room number is {room.Number}");
                Status status = choice == 'Y' ? Status.Active : Status.Inactive;
                room.RoomStatus = choice == 'Y' ? RoomStatus.Occupied : RoomStatus.Booked;
                bool paid = hasRoomService;
                _bookingService.CreateBooking(hotel.Name!, hotel.Id, type.Name!, type.Id, hasRoomService, roomService, room.Number!, room.Id, status, nights, period, price, paid);
                Read();
            }
        }

        private void CheckWallet(string roomTypeId, int nights, RoomService? service, out double price)
        {
            RoomType type = _roomTypeService.Get(type => type.Id == roomTypeId)!;
            User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER")!;
            price = type.Price * nights;
            if (service is not null)
            {
                price += service!.Price;
            }
            if (user.Wallet < (decimal)price)
            {
                Console.WriteLine("Inadequate balance in Wallet!!!");
                price = 0;
                return;
            }
        }

        private void CheckWallet(string hotelId, out double price)
        {
            Hotel hotel = _hotelService.Get(hotel => hotel.Id == hotelId)!;
            User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER")!;

            price = hotel.EarlyCheckOutFee;
            if (user.Wallet < (decimal)price)
            {
                Console.WriteLine("Inadequate balance in Wallet!!!");
                price = 0;
                return;
            }
        }

        private void HotelSection(out Hotel? hotel)
        {
            skip = true;
            ViewAvailableHotels();
            skip = false;

            Console.WriteLine("Choose Hotel to book from (i.e enter 1,2,3,...): ");
            int choice = new();
            generalMenu.EnterChoice(ref choice);

            hotel = _hotelService.IsExist(choice);
            if (hotel is null)
            {
                Console.WriteLine($"Hotel chosen does not exist!!!");
                Read();
                return;
            }
        }

        private void RoomTypeSection(out RoomType? type, string hotelId)
        {
            generalMenu.DisplayRoomTypes(hotelId);
            Console.WriteLine("Choose room type to book from (i.e enter 1,2,3,...)");
            int typeChoice = new();
            generalMenu.EnterChoice(ref typeChoice);

            type = _roomTypeService.IsExist(typeChoice, hotelId);
            if (type is null)
            {
                Console.WriteLine($"Room type chosen does not exist!!!");
                Read();
                return;
            }
        }

        private void RoomSection(out int nights, out DatePeriod period, out Room? room, string roomTypeId, ref char choice)
        {
            int checkInDate = 0;
            Console.Write("Do you want to check in immediately (Y/N): ");
            generalMenu.EnterChoice(ref choice);

            if (choice == 'N')
            {
                Console.Write("How days from now do you want to check in: ");
                generalMenu.EnterChoice(ref checkInDate);
            }

            Console.Write("How many nights are you staying for: ");
            nights = new();
            generalMenu.EnterChoice(ref nights);

            period = new(DateTime.Today.AddDays(checkInDate), DateTime.Today.AddDays(checkInDate + nights));
            room = _roomService.BookRoom(period, roomTypeId);
            if (room is null)
            {
                Console.WriteLine($"There are no available rooms {checkInDate} days from now in the chosen room type!!!");
                Console.WriteLine($"Try Checking in immediately or book from another type");
                Read();
                return;
            }
        }

        private void RoomServiceSection(ref RoomService? roomService, ref bool hasRoomService, string hotelId)
        {
            char choice = 'Y';
            if (skip) goto Skip;
            Console.WriteLine("Do you want hotel to provide you room service (Y/N): ");
            generalMenu.EnterChoice(ref choice);

        Skip:
            if (choice == 'Y')
            {
                int service = new();
                generalMenu.DisplayRoomServices(hotelId);
                Console.WriteLine("Choose room service to be provided (i.e enter 1,2,3,...): ");
                generalMenu.EnterChoice(ref service);

                roomService = _roomServicesService.IsExist(service, hotelId);
                if (roomService is not null)
                {
                    hasRoomService = true;
                }
                else
                {
                    Console.WriteLine($"Room service chosen does not exist!!!");
                    if (!skip) Console.WriteLine("The hotel is not providing you room service");
                }
            }
        }

        private void IncreaseStayPeriod()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER")!;
            Console.WriteLine("Enter how many days you wish to increase stay period");
            int days = new();
            generalMenu.EnterChoice(ref days);


            CheckWallet(bookings[choice].RoomTypeId!, days, null, out double price);
            if (price == 0)
            {
                Console.WriteLine("Consider increasing wallet balance before increasing stay period!!!");
                Read();
                return;
            }
            bool shouldIncrease = _bookingService.ShouldIncreaseStayPeriod(days, bookings[choice]);
            if (shouldIncrease)
            {
                CreditWallet(bookings[choice].HotelId!, price);
                bookings[choice].TotalPriceOfStay += price;
                bookings[choice].StayPeriod.IncreaseEndTime(days);
                bookings[choice].Nights += days;
                _bookingService.UpdateFile();
                Console.WriteLine("Successfully increased stay period!!!");
            }
            else
            {
                Console.WriteLine($"Room booked is not available on {bookings[choice].StayPeriod.End.AddDays(days): dddd, dd mmm, yyyy}!!!");
                Console.WriteLine("Cannot increase stay period!!!");
                Console.WriteLine("Update unsuccessfull!!");
            }
            Read();
        }

        private void ChangeCheckInTime()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            if (bookings[choice].StayPeriod.WithInRange(DateTime.Today))
            {
                Console.WriteLine("Cannot change check in time!!!");
                Console.WriteLine("Can only be changed if user hasn't been checked in");
            }
            else
            {
                Console.Write("How many days from now do you wish to be checked in: ");
                int days = new();
                generalMenu.EnterChoice(ref days);

                bool ShouldChange = _bookingService.ShouldChangeCheckInTime(days, bookings[choice], out DatePeriod period);
                if (ShouldChange)
                {
                    bookings[choice].StayPeriod = period;
                    _bookingService.UpdateFile();
                    Console.WriteLine($"Successfully changed Checkin time!!!");
                }
                else
                {
                    if (DateTime.Today.AddDays(days) > bookings[choice].StayPeriod.End)
                        Console.WriteLine($"New Checkin time has exceeded Checkout time!!!");
                    else
                        Console.WriteLine($"Room booked is not available on {DateTime.Today.AddDays(days): dddd, dd MMMM,yyyy}");
                    Console.WriteLine("Cannot change checkin time!!!");
                    Console.WriteLine("Update unsuccessfull!!");
                }
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
                Console.WriteLine("1. Change room service status");
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
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER")!;
            Hotel hotel = _hotelService.Get(hotel => hotel.Id == bookings[choice].HotelId)!;
            if (!hotel.HasRoomService)
            {
                Console.WriteLine("Hotel is not providing room service!!!");
                Console.WriteLine("Cannot opt in to Room Service function!!!");
                Read();
                return;
            }
            if (bookings[choice].IsRoomService)
            {
                Console.WriteLine("Money paid won't be refunded!!!");
                Console.WriteLine("Are you  sure you want to opt out of the room service function? (Y/N)");
                char input = new();
                generalMenu.EnterChoice(ref input);

                if (input == 'Y')
                {
                    bookings[choice].IsRoomService = false;
                    bookings[choice].RoomService = null;
                    Console.WriteLine("You have opted out of the room service function!!!");
                }
            }
            else
            {
                Console.WriteLine("Are you  sure you want to opt in to the room service function? (Y/N)");
                char input = new();
                generalMenu.EnterChoice(ref input);

                if (input == 'Y')
                {
                    skip = true;
                    bool isRoomService = false;
                    RoomService? service = new();
                    RoomServiceSection(ref service, ref isRoomService, bookings[choice].HotelId!);
                    skip = false;

                    if (!bookings[choice].PaidService)
                    {
                        CheckWallet(bookings[choice].RoomTypeId!, 0, service, out double price);
                        if (price == 0)
                        {
                            Console.WriteLine("Consider increasing wallet balance before opting in for room service!!!");
                            Read();
                            return;
                        }
                        else CreditWallet(bookings[choice].HotelId!, price);
                    }

                    bookings[choice].IsRoomService = isRoomService;
                    bookings[choice].RoomService = service;
                    if (isRoomService)
                    {
                        Console.WriteLine("You have successfully opted in to the room service function!!!");
                    }
                }
                _bookingService.UpdateFile();
                Read();
            }
        }

        private void ChangeRoomServiceType()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            if (bookings[choice].IsRoomService)
            {
                skip = true;
                bool isRoomService = false;
                RoomService? service = new();
                RoomServiceSection(ref service, ref isRoomService, bookings[choice].HotelId!);
                skip = false;

                if (isRoomService)
                {
                    double price = bookings[choice].RoomService!.Price - service!.Price;
                    CreditWallet(bookings[choice].HotelId!, price);
                    bookings[choice].RoomService = service;
                    Console.WriteLine("You have successfully changed room service being provided!!!");
                }
                else
                {
                    Console.WriteLine("Update Unsuccessfull!!!");
                }
            }
            else
            {
                Console.WriteLine("Cannot change room service type!!!\nHotel must be providing user room service in order to change type");
            }
            _bookingService.UpdateFile();
            Read();
        }

        private void ViewRoomDetails()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Hotel Name: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(bookings[choice].Hotel);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Room Type: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(bookings[choice].RoomType!.ToPascalCase());
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Room Number: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(bookings[choice].RoomNumber);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Has Room Service: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(bookings[choice].IsRoomService);
            if (bookings[choice].IsRoomService)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Type of Room Service: ");
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine(bookings[choice].RoomService!.Name!.ToPascalCase());
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Check-in Time: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(bookings[choice].StayPeriod.Start.ToString("dddd, MMMM dd, yyyy"));
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Time to be checked-out: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine(bookings[choice].StayPeriod.End.ToString("dddd, MMMM dd, yyyy"));
            Console.ForegroundColor = ConsoleColor.Gray;
            Read();
        }

        private void ViewBillings()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            RoomType type = _roomTypeService.Get(type => type.Id == bookings[choice].RoomTypeId)!;
            Console.Write("Price of room per night: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine($"N{type.Price:n}");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Total price of room: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            double priceOfRoom = type.Price * bookings[choice].Nights;
            Console.WriteLine($"N{priceOfRoom:n}");
            Console.ForegroundColor = ConsoleColor.Gray;
            
            if (bookings[choice].IsRoomService)
            {
                Console.Write("Price of room service: ");
                Console.ForegroundColor = colours[random.Next(0, colours.Length)];
                Console.WriteLine($"N{bookings[choice].RoomService!.Price:n}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.Write("Total price of stay: ");
            Console.ForegroundColor = colours[random.Next(0, colours.Length)];
            Console.WriteLine($"N{bookings[choice].TotalPriceOfStay:n}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Read();
        }

        private void RateHotel()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            Console.WriteLine("Rate your satisfaction from 1-5");
            int rating = -1;
            while (rating < 1 || rating > 5)
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
                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine("Invalid Input!!!");
                    Console.WriteLine("Try again");
                }
            }

            Hotel hotel = _hotelService.Get(hotel => hotel.Id == bookings[choice].HotelId)!;
            if (hotel.Ratings == 0)
            {
                hotel.Ratings = rating;
            }
            hotel.Ratings = (hotel.Ratings + rating) / 2;
            foreach (Booking booking in bookings)
            {
                if (booking.HotelId == hotel.Id)
                {
                    booking.Rate = true;
                }
            }
            _bookingService.UpdateFile();
            _hotelService.UpdateFile();
            Console.WriteLine("Thanks for your time");
            Read();
        }

        private void CheckOut()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            ChooseBooking(out int choice, out List<Booking> bookings);
            if (choice < 0) return;

            Hotel hotel = _hotelService.Get(hotel => hotel.Id == bookings[choice].HotelId)!;
            Console.WriteLine($"Early Check out will incur N{hotel.EarlyCheckOutFee:n} extra fees");
            Console.WriteLine("Are you sure you want to continue with this operation (Y/N)");
            char choice2 = new();
            generalMenu.EnterChoice(ref choice2);

            if (choice2 == 'Y')
            {
                if (!bookings[choice].Rate)
                {
                    RateHotel();
                }

                CheckWallet(bookings[choice].HotelId!, out double price);
                if (price == 0)
                {
                    Console.WriteLine("Consider increasing wallet balance before checking out!!!");
                    Read();
                    return;
                }

                CreditWallet(bookings[choice].HotelId!, price);
                _bookingService.Delete(bookings[choice]);
                _userService.UpdateFile();
                Console.WriteLine("Successfully Checked-Out");
                Read();
            }

        }

        public void CheckOut(Booking booking)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Check out time has passed!!!");
            Console.WriteLine("Checking Out...");
            if (!booking.Rate)
            {
                RateHotel();
            }
            _bookingService.Delete(booking);
            Console.WriteLine("Successfully Checked-Out");
            Read();
        }

        private void DeleteAccount()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("All details about user will be removed if user deletes account");
            Console.WriteLine("Do you want to continue with this operation (Y/N)");
            char choice = new();
            generalMenu.EnterChoice(ref choice);

            if (choice == 'Y')
            {
                Customer? customer = _customerService.Get(customer => customer.Id == Customer.LoggedInCustomerId);
                if (customer is null)
                {
                    Console.WriteLine("Account not found!!! \nAccount must be registered in order to delete account");
                    Read();
                    return;
                }

                bool isDeleted = _customerService.IsDeleted(customer);
                if (!isDeleted)
                {
                    Console.WriteLine("User is Checked-In in some rooms and therefore cannot delete account!!!\nTry checking out or Try again later");
                    Read();
                    return;
                }
                Console.WriteLine("Successfully deleted account!!!");
                Read();
            }
        }

        private void ChooseBooking(out int choice, out List<Booking> bookings)
        {
            bookings = _bookingService.GetSelected(booking => booking.CustomerID == Customer.LoggedInCustomerId);
            User? user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER");
            if (user is null)
            {
                Console.WriteLine("User must be registered in order to Increase stay period!!!");
                choice = -1;
                Read();
                return;
            }
            choice = 1;
            if (bookings.Count == 0)
            {
                Console.WriteLine("Cannot access this function unless user has booked a room!!!");
                choice = -1;
                Read();
                return;
            }
            else if (bookings.Count > 1)
            {
                DisplayRooms(bookings);
                Console.WriteLine("Choose one of the bookings displayed above (i.e enter 1,2,3,...): ");

                generalMenu.EnterChoice(ref choice);
                if (choice > bookings.Count || choice == 0)
                {
                    Console.WriteLine("Room does not exists!!!");
                    choice = -1;
                    Read();
                    return;
                }
            }
            choice--;
        }

        private void DisplayRooms(List<Booking> bookings)
        {
            int count = 0;
            Console.WriteLine("Viewing all Bookings: ");
            foreach (Booking booking in bookings)
            {
                Console.WriteLine(++count + ". " + booking.ToString());
            }
        }

        private void CreditWallet(string hotelId, double price)
        {
            Hotel hotel = _hotelService.Get(hotel => hotel.Id == hotelId)!;
            User user = _userService.Get(user => user.Email == User.LoggedInUserEmail && user.Role == "CUSTOMER")!;
            Admin admin = _adminService.Get(admin => admin.Id == hotel.AdminId)!;
            User userAdmin = _userService.Get(user => user.Email == admin.UserEmail && user.Role == "ADMIN")!;
            user.Wallet -= (decimal)price;
            userAdmin.Wallet += (decimal)price;
            _userService.UpdateFile();
        }

        private void Read()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}