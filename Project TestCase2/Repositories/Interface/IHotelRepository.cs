using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_TestCase2.Models.Entities;

namespace Project_TestCase2.Repositories.Interface
{
    public interface IHotelRepository
    {
        void Add(Hotel hotel);
        void Remove(Hotel hotel);
        Hotel GetById(int id);
        Hotel GetByName(string name);
        Hotel GetByPos(int choice);
        List<Hotel> GetList(int id);
        List<Hotel> GetAll();
    }
}