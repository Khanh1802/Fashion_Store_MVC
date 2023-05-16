using Fashion_store_web.Dtos.Products;
using Fashion_store_web.Dtos.ProductSizes;
using Fashion_store_web.Dtos.Sizes;
using Fashion_store_web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fashion_store_web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;

        public ProductController(IProductService productService, ISizeService sizeService)
        {
            _productService = productService;
            _sizeService = sizeService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListAsync() ?? new List<ProductDto>();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var sizes = await _sizeService.GetListAsync();
            var sizeSelectList = sizes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();
            return View(new CreateProductDto()
            {
                Sizes = new List<CreateProductSizeDto>(),
                SizeSelectList = sizeSelectList
            });
        }

        [HttpPost]
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
