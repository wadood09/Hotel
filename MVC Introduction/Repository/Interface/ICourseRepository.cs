using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Introduction.Models;

namespace MVC_Introduction.Repository.Interface
{
    public interface ICourseRepository
    {
        List<Course> GetCourses();
    }
}