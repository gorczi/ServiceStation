using Microsoft.AspNetCore.Mvc;

namespace ServiceStation.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult BikeService()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
