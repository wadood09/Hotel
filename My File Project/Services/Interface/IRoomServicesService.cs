using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_File_Project.Services.Interface
{
    public interface IRoomServicesService
    {
        void CreateRoomService(string hotelId, string name, double price);
    }
}