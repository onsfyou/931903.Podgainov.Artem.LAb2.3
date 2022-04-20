using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LAb3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}