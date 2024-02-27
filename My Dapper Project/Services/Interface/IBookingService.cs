using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_Project.Entities;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Models.Enums;

namespace My_Dapper_Project.Services.Interface
{
    public interface IBookingService
    {
        void CreateBooking(string hotelName, string hotelId, string roomType, string roomTypeId, bool isRoomService, RoomService? roomService, string roomNumber, string roomId, Status status, int nights, DatePeriod stayPeriod, double price, bool paidService);
        Booking? Get(Func<Booking, bool> pred);
        List<Booking> GetSelected(Func<Booking, bool> pred);
        List<Booking> GetAll();
        void Delete(Booking booking);
        void UpdateFile();
        void UpdateList();
        bool ShouldIncreaseStayPeriod(int days, Booking booking);
        bool ShouldChangeCheckInTime(int days, Booking booking, out DatePeriod period);
    }
}