using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
{
    public class RoomServicesService : IRoomServicesService
    {
        IRepository<RoomService> repository = new RoomServiceRepository();
        public void CreateRoomService(string hotelId, string name, double price)
        {
            RoomService service = new()
            {
                HotelId = hotelId,
                Name = name,
                Price = price
            };
            repository.Add(service);
        }

        public RoomService? Get(Func<RoomService, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<RoomService> GetSelected(Func<RoomService, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public void Delete(RoomService service)
        {
            repository.Remove(service);
        }

        public bool IsExist(string name, string? hotelId)
        {
            bool service = repository.Get(service => service.Name!.ToUpper() == name.ToUpper() && service.HotelId == hotelId) is not null;
            return service;
        }

        public RoomService? IsExist(int num, string hotelId)
        {
            List<RoomService> service = repository.GetSelected(service => service.HotelId == hotelId);
            if(num > service.Count) return null;
            return service[--num];
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }

        public void UpdateList()
        {
            repository.RefreshList();
        }
    }
}