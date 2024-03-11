using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Introduction.Models;
using MVC_Introduction.Repository.Interface;

namespace MVC_Introduction.Repository.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        List<Course> courses = new()
            {
                new Course{Name = "Java", Content = "Strongly typed programming language"},
                new Course{Name = "C#", Content = "Strongly typed programming language"},
                new Course{Name = "Python", Content = "Strongly typed programming language"},
                new Course{Name = "JavaScript", Content = "Strongly typed programming language"},
            };
        public List<Course> GetCourses()
        {
            return courses;
        }
    }
}