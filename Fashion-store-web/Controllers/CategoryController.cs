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
            try
            {
                var categories = await _categoryService.GetListAsync() ?? new List<CategoryDto>();
                return View(categories);
            }
            catch (Exception)
            {
                return View();
            }
        }
        //public async Task<IActionResult> GetById()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    //Lay id
        //    if (!Request.RouteValues.TryGetValue("id", out var categoryId))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var category = await _categoryService.GetById((Guid)categoryId);
        //    }
        //    return View("Index");
        //}


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
            }
            return RedirectToAction("Index");
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
        public async Task<IActionResult> Update()
        {
            //Lay id
            if (!Request.RouteValues.TryGetValue("id", out var categoryId))
            {
                return RedirectToAction("Index");
            }
            var id = Guid.TryParse(Convert.ToString(categoryId), out Guid result);
            if (id)
            {
                var category = await _categoryService.GetById(result);
                if (category != null)
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
    }
}
