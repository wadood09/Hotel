using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Implementation;
using My_Dapper_Project.Repositories.Interface;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Services.Implementation
{
    public class RoomServicesService : IRoomServicesService
    {
        IRepository<RoomService> repository = new RoomServiceRepository();
        public void CreateRoomService(int typeId, string name, double price)
        {
            var service = new RoomService
            {
                RoomTypeId = typeId,
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

        public bool IsExist(string name, int typeId)
        {
            bool service = Get(service => service.Name!.ToUpper() == name.ToUpper() && service.RoomTypeId == typeId) is not null;
            return service;
        }

        public RoomService? IsExist(int num, int typeId)
        {
            List<RoomService> service = GetSelected(service => service.RoomTypeId == typeId);
            if(num > service.Count) return null;
            return service[--num];
        }

        public void Update(RoomService roomService)
        {
            repository.Update(roomService);
        }
    }
}