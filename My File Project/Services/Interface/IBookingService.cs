using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Entities;
using My_File_Project.Models.Entities;
using My_File_Project.Models.Enums;

namespace My_File_Project.Services.Interface
{
    public interface IBookingService
    {
        void CreateBooking(string hotelName, string hotelId, string roomType, string roomTypeId, double price, bool isRoomService, RoomService roomService, string roomNumber, Status status, int nights, DatePeriod stayPeriod, bool rate);
        Booking? Get(Func<Booking, bool> pred);
        List<Booking> GetSelected(Func<Booking, bool> pred);
        bool IsDeleted(Booking booking);
        void UpdateFile();
    }
}