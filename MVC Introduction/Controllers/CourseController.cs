using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Introduction.Models;
using MVC_Introduction.Repository.Implementation;
using MVC_Introduction.Repository.Interface;

namespace MVC_Introduction.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository repository = new CourseRepository();
        public IActionResult CourseList()
        {
            return View(repository.GetCourses());
        }
    }
}