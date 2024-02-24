using EFPract.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Core.Apllication.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Student Drop(Student student);
        Student Update(Student student);
        Student Get(string email);
        List<Student> GetAll();
        void Delete(Student student);
    }
}
