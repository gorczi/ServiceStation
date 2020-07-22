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
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            var products = _productRepository.GetAll();
            
            switch (sortOrder)
            {
                case "manufacturer_desc":
                    products = products.OrderByDescending(s => s.Manufacturer);
                    break;
                case "Name":
                    products = products.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Category":
                    products = products.OrderBy(s => s.Category);
                    break;
                case "category_desc":
                    products = products.OrderByDescending(s => s.Category);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
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
