using Microsoft.AspNetCore.Mvc;
using ProductClient.Models;
using ProductClient.Service;

namespace ProductClient.Controllers
{
    public class ProductController : Controller
    {
        IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProducts());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product prod)
        {
            Product? result = await _service.CreateProduct(prod);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpGet(Name = "{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Product? result = await _service.GetProduct(id);
            return View(result);
        }

        [HttpPost(Name = "{id}")]
        public async Task<IActionResult> Edit(Product prod)
        {

            Product? result = await _service.UpdateProduct(prod);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
        public ActionResult Delete(int id)
        {
            _service.DeleteProduct(id);

            return RedirectToAction("Index");
        }

    }
}
