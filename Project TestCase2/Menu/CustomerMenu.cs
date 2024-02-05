using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        IRoomTypeManager _roomTypeManager = new RoomTypeManager();
        IManager<Customer> _customerManager = new CustomerManager();
        IRepository<Hotel> _hotelRepository = new HotelRepository();
        IRepository<Customer> _customerRepository = new CustomerRepository();
        IRoomTypeRepository _roomTypeRepository = new RoomTypeRepository();
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

            Customer customer = new(firstName, lastname, email, password);
            _customerManager.Register(customer);
            Read();
        }

        private void Login()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            if (_customerManager.Login(email, password))
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
                Console.WriteLine("1. View Available Hotels");
                Console.WriteLine("2. Book a Room");
                Console.WriteLine("3. Increase Stay Period");
                Console.WriteLine("4. Change Check-In time");
                Console.WriteLine("4. Change Room Service");
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
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
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
            List<Hotel> hotels = _hotelRepository.GetAll();
            if (hotels.Count == 0)
            {
                Console.WriteLine("No Available Hotel at the Moment!!!.\nTry again later");
                Read();
            }
            else
            {
                foreach (var hotel in hotels)
                {
                    Console.WriteLine($"{hotel.Name.ToPascalCase()}    {hotel.Ratings} star ratings");
                    Read();
                }
            }
        }

        private void BookARoom()
        {
            List<Hotel> hotels = _hotelRepository.GetAll();
            Customer loggedInCustomer = _customerRepository.GetById(Customer.LoggedInCustomerId);
            if (hotels.Count == 0)
            {
                Console.WriteLine("No Available Hotel!!!Try again Later");
                Read();
            }
            else
            {
                Console.WriteLine("Choose Hotel to book from: ");
                ViewAvailableHotels();
                string choice = Console.ReadLine();
                Hotel hotel = _hotelRepository.GetByName(choice);
                _roomTypeManager.DisplayRoomTypes(hotel.Id);
                string room = Console.ReadLine();
                RoomType type = _roomTypeRepository.Get(hotel.Id, room);
                if (type.Status == Models.Enums.RoomTypeStatus.Available)
                {
                    int date;
                    bool roomService = false;;
                    Console.Write("Do you want to check in immediately (Y/N)");
                    char choice2 = char.Parse(Console.ReadLine().ToUpper());
                    if (choice2 != 'Y')
                    {
                        Console.Write("How days from now do you want to check in: ");
                        date = int.Parse(Console.ReadLine());
                    }
                    Console.Write("How many nights are you staying for: ");
                    int nights = int.Parse(Console.ReadLine());
                    if (hotel.RoomService)
                    {
                        Console.WriteLine("Do you want hotel to provide room service: ");
                        char choice3 = char.Parse(Console.ReadLine().ToUpper());
                        if (choice3 == 'Y')
                        {
                            
                        }
                    }
                }

                loggedInCustomer.TotalPriceOfStay = (decimal)hotel.RoomPrices[room] * nights;
                char input;
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

        private void Read()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}