using Fashion_store_web.Dtos.Sizes;
using Fashion_store_web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_store_web.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        public async Task<IActionResult> Index()
        {
            var sizes = await _sizeService.GetListAsync();
            return View(sizes);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSizeDto item)
        {
            if (ModelState.IsValid)
            {
                var create = await _sizeService.CreateAsync(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Update()
        {
            //Lay id
            if (!Request.RouteValues.TryGetValue("id", out var sizeId))
            {
                return RedirectToAction("Index");
            }
            var IsValidId = Guid.TryParse(Convert.ToString(sizeId), out Guid id);
            if (IsValidId)
            {
                var size = await _sizeService.GetById(id);
                if (size.Id != Guid.Empty && size.Id != null)
                {
                    return View(new UpdateSizeDto()
                    {
                        Id = size.Id,
                        Name = size.Name,
                        Code = size.Code
                    });
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSizeDto item)
        {
            if (ModelState.IsValid)
            {
                var update = await _sizeService.UpdateAsync(item);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            //Lay id
            if (!Request.RouteValues.TryGetValue("id", out var sizeId))
            {
                return RedirectToAction("Index");
            }
            var IsValidId = Guid.TryParse(Convert.ToString(sizeId), out Guid id);
            if (IsValidId)
            {
                var size = await _sizeService.GetById(id);
                if (size.Id != Guid.Empty && size.Id != null)
                {
                    return View(new SizeDto()
                    {
                        Id = size.Id,
                        Name = size.Name,
                        Code = size.Code,
                        CreationTime = size.CreationTime,
                        LastModificationTime = size.LastModificationTime,
                    });
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateSizeDto item)
        {
            if (ModelState.IsValid)
            {
                await _sizeService.DeleteAsync(item.Id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
