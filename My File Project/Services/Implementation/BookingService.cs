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
        public void CreateBooking(string hotelName, string hotelId, string roomType, string roomTypeId, bool isRoomService, RoomService? roomService, string roomNumber, string roomId, Status status, int nights, DatePeriod stayPeriod, double price, bool paidService)
        {
            Booking booking = new()
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
                StayPeriod = stayPeriod,
                TotalPriceOfStay = price,
                PaidService = paidService
            };
            repository.Add(booking);
        }

        public Booking? Get(Func<Booking, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<Booking> GetSelected(Func<Booking, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public void Delete(Booking booking)
        {
            repository.Remove(booking);
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }

        public void UpdateList()
        {
            repository.RefreshList();
        }

        public bool ShouldIncreaseStayPeriod(int days, Booking booking)
        {
            DateTime checkOutDate = booking.StayPeriod.End.AddDays(days);
            List<Booking> bookings = repository.GetSelected(bookin => bookin.RoomId == booking.RoomId);
            foreach (Booking booking1 in bookings)
            {
                if (booking1 == booking) continue;
                if (booking1.StayPeriod.WithInRange(checkOutDate))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ShouldChangeCheckInTime(int days, Booking booking, out DatePeriod newPeriod)
        {
            DateTime newCheckInDate = DateTime.Today.AddDays(days);
            DateTime newCheckOutDate = newCheckInDate.AddDays(booking.Nights);
            newPeriod = new(newCheckInDate, newCheckOutDate);

            if (newCheckInDate >= booking.StayPeriod.End) return false;

            List<Booking> bookings = repository.GetSelected(bookin => bookin.RoomId == booking.RoomId);
            foreach (Booking booking1 in bookings)
            {
                if(booking == booking1) continue;
                if (booking.StayPeriod.Intersects(newPeriod))
                {
                    return false;
                }
            }
            return true;
        }

        public List<Booking> GetAll()
        {
            return repository.GetAll();
        }
    }
}