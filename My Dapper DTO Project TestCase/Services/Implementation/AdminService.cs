using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;
using My_Dapper_DTO_Project_Testcase.Models.Enums;
using My_Dapper_DTO_Project_Testcase.Repositories.Implementation;
using My_Dapper_DTO_Project_Testcase.Repositories.Interface;
using My_Dapper_DTO_Project_Testcase.Services.Interface;
using My_Dapper_DTO_Project_TestCase.Models.Exceptions;

namespace My_Dapper_DTO_Project_Testcase.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private static string _connectionString = default!;
        public AdminService(string connectionString)
        {
            _connectionString = connectionString;
        }
        IRepository<Admin> repository = new AdminRepository(_connectionString);
        IRepository<Hotel> hotelRepo = new HotelRepository(_connectionString);
        IHotelService hotelService = new HotelService();
        IUserService userService = new UserService();
        public void CreateAdmin(AdminResquestModel model)
        {
            Admin admin = new()
            {
                UserEmail = model.UserEmail
            };
            repository.Add(admin);
        }

        public AdminResponseModel? Get(Func<Admin, bool> pred)
        {
            Admin? admin = repository.GetAll().SingleOrDefault(pred);
            if (admin is null) return null;
            AdminResponseModel model = new()
            {
                UserEmail = admin.UserEmail,
                Id = admin.Id
            };
            return model;
        }
        public List<AdminResponseModel> GetSelected(Func<Admin, bool> pred)
        {
            return repository.GetAll().Where(pred).Select(admin => new AdminResponseModel()
            {
                UserEmail = admin.UserEmail,
                Id = admin.Id
            }).ToList();
        }

        public bool IsDeleted(Admin admin)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        List<HotelResponseModel> models = hotelService.GetSelected(hotel => hotel.AdminId == admin.Id);
                        bool isActive = models.Any(hotel => hotel.HotelStatus == Status.Active);
                        if (isActive) return false;

                        foreach (HotelResponseModel model in models)
                        {
                            Hotel hotel = hotelRepo.GetAll().SingleOrDefault(hotel => hotel.Id == model.Id)!;
                            bool isDeleted = hotelService.IsDeleted(hotel);
                            if (!isDeleted) throw new InvalidConditionException();
                        }
                        User user = userService.Get(user => user.Email == admin.UserEmail && user.Role == "ADMIN")!;
                        userService.Delete(user);
                        repository.Remove(admin);
                        transaction.Commit();
                        return true;
                    }
                    catch (InvalidConditionException exception)
                    {
                        Console.WriteLine(exception.Message);
                        transaction.Rollback();
                        return false;
                    }
                }
            }

        }

        public void Update(Admin admin)
        {
            repository.Update(admin);
        }
    }
}