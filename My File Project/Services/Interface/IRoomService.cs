using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_File_Project.Entities;
using My_File_Project.Models.Entities;

namespace My_File_Project.Services.Interface
{
    public interface IRoomService
    {
        Room? BookRoom(DatePeriod period, string roomTypeId);
        void CreateRoom(string hotelId, string roomTypeId, string number);
        Room? Get(Func<Room, bool> pred);
        List<Room> GetSelected(Func<Room, bool> pred);
        bool IsDeleted(Room room);
        bool IsExist(string num, string roomTypeId);
        void UpdateFile();
        void UpdateList();
    }
}