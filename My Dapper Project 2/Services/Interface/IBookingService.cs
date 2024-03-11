
using My_Dapper_Project_2.Entities;
using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Models.Enums;

namespace My_Dapper_Project_2.Services.Interface
{
    public interface IBookingService
    {
        void CreateBooking(string hotelName, int hotelId, string roomType, int roomTypeId, bool isRoomService, RoomService? roomService, string roomNumber, int roomId, Status status, int nights, DatePeriod stayPeriod, double price, bool paidService);
        Booking? Get(Func<Booking, bool> pred);
        List<Booking> GetSelected(Func<Booking, bool> pred);
        List<Booking> GetAll();
        void Delete(Booking booking);
        void Update(Booking booking);
        bool ShouldIncreaseStayPeriod(int days, Booking booking);
        bool ShouldChangeCheckInTime(int days, Booking booking, out DateTime newCheckInDate, out DateTime newCheckOutDate);
    }
}