using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Id {  get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
