using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly string _connectionString;
        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Booking booking)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Insert into Bookings 
                (Hotel, HotelId, RoomType, RoomTypeId, IsRoomService, RoomServiceId, RoomNumber, RoomId, CustomerId, CustomerStatus, Nights, StayPeriod, CheckInDate, CheckOutDate, TotalPriceOfStay, Rate, PaidService) 
                values(@Hotel, @HotelId, @RoomType, @RoomTypeId, @IsRoomService, @RoomServiceId, @RoomNumber, @RoomId, @CustomerId, @CustomerStatus, @Nights, @StayPeriod, @CheckInDate, @CheckOutDate, @TotalPriceOfStay, @Rate, @PaidService)";
                dbConnection.Execute(query, booking);
            }
        }

        public IEnumerable<Booking> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "select * from Bookings";

                return dbConnection.Query<Booking>(query);
            }
        }

        public void Remove(Booking Booking)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from Admins where Id = @Id";
                dbConnection.Execute(query, Booking);
            }
        }

        public void Update(Booking booking)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"Update Bookings 
                Set Hotel = @Hotel,
                HotelId = @HotelId,
                RoomType = @RoomType,
                RoomTypeId = @RoomTypeId,
                IsRoomService = @IsRoomService,
                RoomServiceId = RoomServiceId,
                RoomNumber = @RoomNumber,
                RoomId = @RoomId,
                CustomerId = @CustomerId,
                CustomerStatus = @CustomerStatus,
                Nights = @Nights,
                StayPeriod = @StayPeriod,
                CheckInDate = @CheckInDate,
                CheckOutDate = @CheckOutDate,
                TotalPriceOfStay = @TotalPriceOfStay,
                Rate = @Rate,
                PaidService = @PaidService";
                dbConnection.Execute(query, booking);
            }
        }
    }
}