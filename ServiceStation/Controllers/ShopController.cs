using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Core.Shop;
using ServiceStation.Data.Services;
using ServiceStation.Helpers;
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
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ManufacturerSortParm"] = sortOrder == "Manufacturer" ? "manufacturer_desc" : "Manufacturer";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var products = _productRepository.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products
                    .Where(s => s.Manufacturer.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
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
            int pageSize = 10;
         
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
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
