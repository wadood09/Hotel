using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models.Entities
{
    public abstract class Auditable
    {
        public string Id {get; set;} = Guid.NewGuid().ToString().Substring(0, 5);
        public bool IsDeleted = false;
    }
}