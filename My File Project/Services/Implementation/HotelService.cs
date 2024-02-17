using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Implementation;
using My_File_Project.Repositories.Interface;
using My_File_Project.Services.Interface;

namespace My_File_Project.Services.Implementation
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
    }
}