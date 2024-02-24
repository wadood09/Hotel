using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Core.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string UserEmail { get; set; } = default!;
        public string MatricNumber { get; set; } = default!;
        public string Level { get; set; } = default!;
        public string Department { get; set; } = default!;

    }
}
