using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;
using My_Dapper_DTO_Project_Testcase.Repositories.Implementation;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;
using My_Dapper_DTO_Project_Testcase.Services.Interface;

namespace My_Dapper_DTO_Project_Testcase.Services.Implementation
{
    public class HotelService : IHotelService
    {
        IRepository<Hotel> repository = new HotelRepository();
        IRoomTypeService typeService = new RoomTypeService();
        IRoomServicesService servicesService = new RoomServicesService();
        public Hotel? CreateHotel(string name, bool hasRoomService, double checkOutFee, List<string> roomTypes, List<double> roomPrices, List<int> roomAmount, List<List<string>> roomNumbers, List<string> roomServices, List<double> servicePrices)
        {
            if (IsExist(name)) return null;

            Hotel hotel = new()
            {
                Name = name,
                HasRoomService = hasRoomService,
                AdminId = Admin.LoggedInAdminId,
                Ratings = 0,
                EarlyCheckOutFee = checkOutFee
            };

            for (int i = 0; i < roomTypes.Count; i++)
            {
                typeService.CreateRoomType(hotel.Id, roomTypes[i], roomAmount[i], roomPrices[i], roomNumbers[i]);
            }

            if (hasRoomService)
            {
                for (int i = 0; i < roomServices.Count; i++)
                {
                    servicesService.CreateRoomService(hotel.Id, roomServices[i], servicePrices[i]);
                }
            }
            repository.Add(hotel);
            return hotel;
        }

        public bool IsExist(string name)
        {
            bool isExist = repository.GetAll().Select(hotel => hotel.Name!.ToUpper()).Contains(name.ToUpper());
            return isExist;
        }

        public Hotel? Get(Func<Hotel, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<Hotel> GetSelected(Func<Hotel, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }

        public void UpdateList()
        {
            repository.RefreshList();
        }

        public bool IsDeleted(Hotel hotel)
        {
            if (hotel.HotelStatus == Status.Active) return false;
            List<RoomType> types = typeService.GetSelected(type => type.HotelId == hotel.Id);
            foreach (RoomType type in types)
            {
                bool isDeleted = typeService.IsDeleted(type);
                if (!isDeleted) return false;
            }

            List<RoomService> services = servicesService.GetSelected(service => service.HotelId == hotel.Id);
            foreach (RoomService service in services)
            {
                servicesService.Delete(service);
            }
            repository.Remove(hotel);
            return true;
        }

        public List<Hotel> GetAll()
        {
            return repository.GetAll();
        }

        public Hotel? IsExist(int pos)
        {
            List<Hotel> hotels = repository.GetAll();
            if (pos > hotels.Count || pos == 0) return null;
            else return hotels[--pos];
        }
    }
}