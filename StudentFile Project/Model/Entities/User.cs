using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Enum;

namespace StudentFile_Project.Model.Entities
{
    public class User : BaseEntities
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PassWord { get; set; } = default!;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; } = default!;
        public static User LoggedInUser{get;set;} = default!;

    }


}