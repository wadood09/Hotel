using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Introduction.Models;

namespace MVC_Introduction.Controllers
{
    public class BodyController : Controller
    {
        public IActionResult FAQ()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    }
}