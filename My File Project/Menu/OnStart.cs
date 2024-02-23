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
            string[] filePaths = new string[] { HotelContext.AdminFile, HotelContext.BookingFile, HotelContext.CustomerFile, HotelContext.HotelFile, HotelContext.RoomFile, HotelContext.RoomServiceFile, HotelContext.RoomTypeFile, HotelContext.UserFile };
            foreach (string path in filePaths)
            {
                using (StreamWriter writer = new(path, true)) { }
            }
            _adminService.UpdateList();

            _bookingService.UpdateList();

            _customerService.UpdateList();

            _hotelService.UpdateList();

            _roomService.UpdateList();

            _roomTypeService.UpdateList();

            _roomServicesService.UpdateList();

            _userService.UpdateList();
        }
    }
}