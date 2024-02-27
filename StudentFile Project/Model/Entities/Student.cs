using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFile_Project.Model.Entities
{
    public class Student : BaseEntities
    {
        public string UserEmail{get;set;} = default!;
        public string RegNumber{get;set;} = default!;
        public static string LoggedInStudentId {get;set;}=default!;
    }
}