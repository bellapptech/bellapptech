using Microsoft.AspNetCore.Mvc;

namespace BellAppTech.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult BSPalletPro() => View();
        public IActionResult BSWeightPro() => View();
    }
}