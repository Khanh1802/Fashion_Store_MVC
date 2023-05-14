using Fashion_store_web.Dtos.Products;
using Fashion_store_web.Dtos.Sizes;
using Fashion_store_web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_store_web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListAsync() ?? new List<ProductDto>();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(CreateProductDto item)
        {
            if (ModelState.IsValid)
            {
                var create = await _productService.CreateAsync(item);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
