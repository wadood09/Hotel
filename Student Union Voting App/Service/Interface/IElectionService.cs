using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Union_Voting_App.Models.Entities;

namespace Student_Union_Voting_App.Service.Interface
{
    public interface IElectionService
    {
        Election CreateElection(string name, DatePeriod votingDatePeriod,TimePeriod votingTimePeriod, List<int> positionId);
    }
}