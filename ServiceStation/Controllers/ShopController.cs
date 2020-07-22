﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Data.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStation.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ShopController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            ViewData["ManufacturerSortParm"] = String.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var products = _productRepository.GetAll();
            
            switch (sortOrder)
            {
                case "manufacturer_desc":
                    products = products.OrderByDescending(s => s.Manufacturer);
                    break;
                //case "Date":
                //    products = products.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    products = products.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    products = products.OrderBy(s => s.Manufacturer);
                    break;
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _productRepository.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

    }
}
