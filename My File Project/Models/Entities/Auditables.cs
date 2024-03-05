using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_File_Project.Models.Entities
{
    public abstract class Auditables
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 5);
    }
}