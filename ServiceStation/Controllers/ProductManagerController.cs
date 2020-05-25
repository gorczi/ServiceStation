using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Core.Shop;
using ServiceStation.Data.Services;

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

        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
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