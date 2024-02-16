using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Models.Enums;

namespace Student_Union_Voting_App.Service.Interface
{
    public interface IUserService
    {
        User CreateUser(string email, string role, string password, string firstName, string lastName, Gender gender, DateTime dob);
        bool Login(string email, string password);
    }
}