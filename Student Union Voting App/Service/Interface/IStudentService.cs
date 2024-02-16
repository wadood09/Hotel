using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Union_Voting_App.Models.Entities;
using Student_Union_Voting_App.Models.Enums;

namespace Student_Union_Voting_App.Service.Interface
{
    public interface IStudentService
    {
        Student CreateStudent(string firstName, string lastName, string email, string password, Gender gender, DateTime dob, string matricNo, int gp, int level);
    }
}