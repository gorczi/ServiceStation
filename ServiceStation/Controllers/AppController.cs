using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
