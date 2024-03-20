using MicroServicos.Web.Models;
using MicroServicos.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicos.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _service.FindAllProducts();
            return View(products);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreateProduct(model);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }
    }
}
