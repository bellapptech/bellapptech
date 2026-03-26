using Microsoft.AspNetCore.Mvc;

namespace BellAppTech.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Services() => View();
        public IActionResult About() => View();
    }
}