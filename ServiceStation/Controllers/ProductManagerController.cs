using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Core.Shop;
using ServiceStation.Data.Services;
using System;
using System.Linq;

namespace ServiceStation.Controllers
{
    [Authorize(Roles = "ProductManager")]
    public class ProductManagerController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductManagerController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["ManufacturerSortParm"] = String.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "Manufacturer";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;

            var products = _productRepository.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products
                    .Where(s => s.Manufacturer.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
                                       || s.Name.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    products = products.OrderByDescending(p => p.Id);
                    break;
                case "Manufacturer":
                    products = products.OrderBy(p => p.Manufacturer);
                    break;
                case "manufacturer_desc":
                    products = products.OrderByDescending(p => p.Manufacturer);
                    break;
                case "Name":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Category":
                    products = products.OrderBy(p => p.Category);
                    break;
                case "category_desc":
                    products = products.OrderByDescending(p => p.Category);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Id);
                    break;
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("Details", new { id = product.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productRepository.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction("Details", new { id = product.Id });
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _productRepository.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection form)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }

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