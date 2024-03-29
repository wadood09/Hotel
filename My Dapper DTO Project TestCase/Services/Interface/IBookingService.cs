using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface IBookingService
    {
        void CreateBooking(BookingResquestModel booking);
        BookingResponseModel? Get(Func<Booking, bool> pred);
        Booking? Get(Func<Booking, bool> pred, string serv);
        List<BookingResponseModel> GetSelected(Func<Booking, bool> pred);
        List<Booking> GetSelected(Func<Booking, bool> pred, string serv);
        List<BookingResponseModel> GetAll();
        List<Booking> GetAll(string serv);
        void Delete(Booking booking);
        void Update();
        bool ShouldIncreaseStayPeriod(int days, Booking booking);
        bool ShouldChangeCheckInTime(int days, Booking booking, out DatePeriod period);
    }
}