using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;
using My_Dapper_DTO_Project_Testcase.Repositories.Implementation;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;
using My_Dapper_DTO_Project_Testcase.Services.Interface;

namespace My_Dapper_DTO_Project_Testcase.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private static string _connectionString = default!;
        public BookingService(string connectionString)
        {
            _connectionString = connectionString;
        }
        IRepository<Booking> repository = new BookingRepository(_connectionString);
        public void CreateBooking(BookingResquestModel model)
        {
            Booking booking = new()
            {
                Hotel = model.Hotel,
                HotelId = model.HotelId,
                RoomType = model.RoomType,
                RoomTypeId = model.RoomTypeId,
                IsRoomService = model.IsRoomService,
                RoomService = model.RoomService,
                RoomNumber = model.RoomNumber,
                RoomId = model.RoomId,
                CustomerID = Customer.LoggedInCustomerId,
                CustomerStatus = model.CustomerStatus,
                Nights = model.Nights,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                TotalPriceOfStay = model.TotalPriceOfStay,
                PaidService = model.PaidService
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