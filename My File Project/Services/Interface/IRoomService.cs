using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_File_Project.Services.Interface
{
    public interface IRoomService
    {
        void CreateRoom(string hotelId, string roomTypeId, string number);
    }
}