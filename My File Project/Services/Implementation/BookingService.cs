using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Entities;
using My_File_Project.Models.Entities;
using My_File_Project.Models.Enums;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class BookingService : IBookingService
    {
        IRepository<Booking> repository = new BookingRepository();
        public void CreateBooking(string hotelName, string hotelId, string roomType, string roomTypeId, double price, bool isRoomService, RoomService roomService, string roomNumber, Status status, int nights, DatePeriod stayPeriod, bool rate)
        {
            Booking booking = new()
            {
                Hotel = hotelName,
                HotelId = hotelId,
                RoomType = roomType,
                RoomTypeId = roomTypeId,
                Price = price,
                IsRoomService = isRoomService,
                RoomService = roomService,
                RoomNumber = roomNumber,
                CustomerID = Customer.LoggedInCustomerId,
                CustomerStatus = status,
                Nights = nights,
                StayPeriod = stayPeriod,
                Rate = rate
            };
        }
    }
}