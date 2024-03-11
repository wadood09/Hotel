using My_Dapper_Project.Entities;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Models.Enums;
using My_Dapper_Project.Repositories.Implementation;
using My_Dapper_Project.Repositories.Interface;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Services.Implementation
{
    public class BookingService : IBookingService
    {
        IRepository<Booking> repository = new BookingRepository();
        public void CreateBooking(string hotelName, int hotelId, string roomType, int roomTypeId, bool isRoomService, RoomService? roomService, string roomNumber, int roomId, Status status, int nights, DatePeriod stayPeriod, double price, bool paidService)
        {
            var booking = new Booking
            {
                Hotel = hotelName,
                HotelId = hotelId,
                RoomType = roomType,
                RoomTypeId = roomTypeId,
                IsRoomService = isRoomService,
                RoomService = roomService,
                RoomNumber = roomNumber,
                RoomId = roomId,
                CustomerID = Customer.LoggedInCustomerId,
                CustomerStatus = status,
                Nights = nights,
                CheckInDate = stayPeriod.Start,
                CheckOutDate = stayPeriod.End,
                TotalPriceOfStay = price,
                PaidService = paidService
            };
            repository.Add(booking);
        }

        public Booking? Get(Func<Booking, bool> pred)
        {
            return repository.GetAll().SingleOrDefault(pred);
        }

        public List<Booking> GetSelected(Func<Booking, bool> pred)
        {
            return repository.GetAll().Where(pred).ToList();
        }

        public void Delete(Booking booking)
        {
            repository.Remove(booking);
        }


        public bool ShouldIncreaseStayPeriod(int days, Booking booking)
        {
            DateTime newCheckOutDate = booking.CheckOutDate.AddDays(days);
            bool shouldIncreaseStayPeriod = new();
            List<Booking> bookings = GetSelected(bookin => bookin.RoomId == booking.RoomId);

            shouldIncreaseStayPeriod = bookings.SkipWhile(bookin => bookin.Id == booking.Id).
            Select(booking => new DatePeriod(booking.CheckInDate, booking.CheckOutDate))
            .All(stayPeriod => !stayPeriod.WithInRange(newCheckOutDate));
            return shouldIncreaseStayPeriod;
        }

        public bool ShouldChangeCheckInTime(int days, Booking booking, out DateTime newCheckInDate, out DateTime newCheckOutDate)
        {
            newCheckInDate = DateTime.Today.AddDays(days);
            newCheckOutDate = newCheckInDate.AddDays(booking.Nights);
            DatePeriod newPeriod = new(newCheckInDate, newCheckOutDate);

            if (newCheckInDate >= booking.CheckOutDate) return false;

            List<Booking> bookings = GetSelected(bookin => bookin.RoomId == booking.RoomId);
            bool shouldChangeCheckInTime = new();

            shouldChangeCheckInTime = bookings.SkipWhile(bookin => bookin.Id == booking.Id).
            Select(booking => new DatePeriod(booking.CheckInDate, booking.CheckOutDate))
            .All(stayPeriod => !stayPeriod.Intersects(newPeriod));
            return shouldChangeCheckInTime;
        }

        public List<Booking> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public void Update(Booking booking)
        {
            repository.Update(booking);
        }
    }
}