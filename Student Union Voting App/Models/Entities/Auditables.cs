using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Union_Voting_App.Models.Entities
{
    public class Auditables
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 5);
        public DateTime DateCreated { get; set; }
        public bool IsDeleted = false;
    }
}