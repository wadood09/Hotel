using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Union_Voting_App.Models.Entities;

namespace Student_Union_Voting_App.Service.Interface
{
    public interface IECService
    {
        ElectoralChairman CreateElectoralChairman(int electoralChairmanId, string matricNo, string electionName);
    }
}