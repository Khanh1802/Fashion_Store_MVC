using Fashion_store_web.Dtos.Categories;
using Fashion_store_web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_store_web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetListAsync() ?? new List<CategoryDto>();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto item)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            //Lay id
            if (!Request.RouteValues.TryGetValue("id", out var categoryId))
            {
                return RedirectToAction("Index");
            }
            var IsValidId = Guid.TryParse(Convert.ToString(categoryId), out Guid id);
            if (IsValidId)
            {
                var category = await _categoryService.GetById(id);
                if (category.Id != Guid.Empty && category.Id != null)
                {
                    return View(new CategoryDto()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Order = category.Order,
                        ParentId = category.ParentId,
                        Slug = category.Slug,
                        CreationTime = category.CreationTime,
                        LastModificationTime = category.LastModificationTime,
                    });
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.DeleteAsync(id);
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update()
        {
            //Lay id
            if (!Request.RouteValues.TryGetValue("id", out var categoryId))
            {
                return RedirectToAction("Index");
            }
            var IsValidId = Guid.TryParse(Convert.ToString(categoryId), out Guid id);
            if (IsValidId)
            {
                var category = await _categoryService.GetById(id);
                if (category.Id != Guid.Empty && category.Id != null)
                {
                    return View(new UpdateCategoryDto()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        ParentId = category.ParentId,
                        Slug = category.Slug
                    });
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto item)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(item);
            }
            return RedirectToAction("Index");
        }
    }
}
