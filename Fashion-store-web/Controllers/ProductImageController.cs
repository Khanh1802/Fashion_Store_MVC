using Fashion_store_web.Dtos.ProductImage;
using Fashion_store_web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_store_web.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IActionResult> Index()
        {
            var productImages = await _productImageService.GetListAsync();
            return View(productImages);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductImageDto item)
        {
            if (ModelState.IsValid)
            {
                await _productImageService.CreateAsync(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Update()
        {

            if (Request.RouteValues.TryGetValue("Id", out var productImageId))
            {
                if (Guid.TryParse(Convert.ToString(productImageId), out Guid id))
                {
                    var productImage = await _productImageService.GetById(id);
                    if (productImage.Id != Guid.Empty && productImage.Id != null)
                    {
                        return View(new UpdateProductImageDto
                        {
                            ProductId = productImage.ProductId,
                            Id = productImage.Id,
                            Name = productImage.Name,
                            ShortName = productImage.ShortName,
                            Description = productImage.Description,
                            Slug = productImage.Slug,
                        });
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductImageDto item)
        {
            if (ModelState.IsValid)
            {
                await _productImageService.UpdateAsync(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete()
        {

            if (Request.RouteValues.TryGetValue("Id", out var productImageId))
            {
                if (Guid.TryParse(Convert.ToString(productImageId), out Guid id))
                {
                    var productImage = await _productImageService.GetById(id);
                    if (productImage.Id != Guid.Empty && productImage.Id != null)
                    {
                        return View(productImage);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductImageDto item)
        {
            if (ModelState.IsValid)
            {
                await _productImageService.DeleteAsync(item.Id.Value);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
