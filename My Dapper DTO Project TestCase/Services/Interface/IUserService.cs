using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Dapper_DTO_Project_Testcase.DTO;
using My_Dapper_DTO_Project_Testcase.Models.Entities;

namespace My_Dapper_DTO_Project_Testcase.Services.Interface
{
    public interface IUserService
    {
        UserResponseModel? CreateUser(UserRequestModel model);
        UserResponseModel? Get(Func<User, bool> pred);
        User? Get(Func<User, bool> pred, string serv);
        List<UserResponseModel> GetSelected(Func<User, bool> pred);
        List<User> GetSelected(Func<User, bool> pred, string serv);
        void Delete(User user);
        (bool, List<UserResponseModel>) Login(string email, string password);
        void Update();
    }
}