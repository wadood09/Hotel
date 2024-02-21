using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Context;
using My_File_Project.Services.Implementation;
using My_File_Project.Services.Interface;

namespace My_File_Project.Menu
{
    public class OnStart
    {
        IAdminService _adminService = new AdminService();
        IHotelService _hotelService = new HotelService();
        IRoomService _roomService = new RoomServices();
        IRoomServicesService _roomServicesService = new RoomServicesService();
        IRoomTypeService _roomTypeService = new RoomTypeService();
        IUserService _userService = new UserService();
        IBookingService _bookingService = new BookingService();
        ICustomerService _customerService = new CustomerService();
        public void Check()
        {
            if (!Directory.Exists("Files"))
            {
                Directory.CreateDirectory("Files");
            }
            if (!File.Exists(HotelContext.AdminFile)) File.Create(HotelContext.AdminFile);
            else _adminService.UpdateList();

            if (!File.Exists(HotelContext.BookingFile)) File.Create(HotelContext.BookingFile);
            else _bookingService.UpdateList();

            if (!File.Exists(HotelContext.CustomerFile)) File.Create(HotelContext.CustomerFile);
            else _customerService.UpdateList();

            if (!File.Exists(HotelContext.HotelFile)) File.Create(HotelContext.HotelFile);
            else _hotelService.UpdateList();

            if (!File.Exists(HotelContext.RoomFile)) File.Create(HotelContext.RoomFile);
            else _roomService.UpdateList();

            if (!File.Exists(HotelContext.RoomTypeFile)) File.Create(HotelContext.RoomTypeFile);
            else _roomTypeService.UpdateList();

            if (!File.Exists(HotelContext.RoomServiceFile)) File.Create(HotelContext.RoomServiceFile);
            else _roomServicesService.UpdateList();

            if (!File.Exists(HotelContext.UserFile)) File.Create(HotelContext.UserFile);
            else _userService.UpdateList();
        }
    }
}