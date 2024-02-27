using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFile_Project.Model.Entities
{
    public class BaseEntities
    {
        public string Id{get; set;} = Guid.NewGuid().ToString().Substring(0,5);
        public bool IsDeleted = false;
    }
}