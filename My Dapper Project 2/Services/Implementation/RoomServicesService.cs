using My_Dapper_Project_2.Models.Entities;
using My_Dapper_Project_2.Repositories.Implementation;
using My_Dapper_Project_2.Repositories.Interface;
using My_Dapper_Project_2.Services.Interface;

namespace My_Dapper_Project_2.Services.Implementation
{
    public class RoomServicesService : IRoomServicesService
    {
        IRepository<RoomService> repository = new RoomServiceRepository();
        public void CreateRoomService(int hotelId, string name, double price)
        {
            var service = new RoomService
            {
                HotelId = hotelId,
                Name = name,
                Price = price
            };
            repository.Add(service);
        }

        public RoomService? Get(Func<RoomService, bool> pred)
        {
            return repository.GetAll().SingleOrDefault(pred);
        }

        public List<RoomService> GetSelected(Func<RoomService, bool> pred)
        {
            return repository.GetAll().Where(pred).ToList();
        }

        public void Delete(RoomService service)
        {
            repository.Remove(service);
        }

        public bool IsExist(string name, int hotelId)
        {
            bool service = Get(service => service.Name!.ToUpper() == name.ToUpper() && service.HotelId == hotelId) is not null;
            return service;
        }

        public RoomService? IsExist(int num, int hotelId)
        {
            List<RoomService> service = GetSelected(service => service.HotelId == hotelId);
            if(num > service.Count) return null;
            return service[--num];
        }

        public void Update(RoomService roomService)
        {
            repository.Update(roomService);
        }
    }
}