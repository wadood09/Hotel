using EFPract.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Core.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
    }
}
