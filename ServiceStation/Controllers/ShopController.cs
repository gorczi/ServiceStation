using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Core.Services;

namespace ServiceStation.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository productRepository;

        public ShopController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(productRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = productRepository.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
    }
}
