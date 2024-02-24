using EFPract.Core.Apllication.Interfaces.Repositories;
using EFPract.Core.Domain.Entities;
using EFPract.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        StudContext _context = new StudContext();

        public void Delete(Student student)
        {
            _context.Set<Student>().Remove(student);
        }

        public Student Drop(Student student)
        {
            //_context.Students.Add(student);
            _context.Set<Student>().Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Get(string email)
        {
            var student = _context.Set<Student>().SingleOrDefault(a => a.UserEmail == email);
            //_context.Students.SingleOrDefault(a => a.UserEmail == email);
            return student;
                
        }

        public List<Student> GetAll()
        {
            return _context.Set<Student>().ToList();
        }

        public Student Update(Student student)
        {
            _context.Set<Student>().Update(student);
            _context.SaveChanges();
            return student;
                
        }
    }
}
