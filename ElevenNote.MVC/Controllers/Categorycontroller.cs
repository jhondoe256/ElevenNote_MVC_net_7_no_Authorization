using ElevenNote.Models.CategoryModels;
using ElevenNote.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNote.MVC.Controllers
{
    [Route("[controller]")]
    public class Categorycontroller : Controller
    {
        private ICategoryService _categoryService;

        public Categorycontroller(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetCategories());
        }

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            return View();
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(CategoryCreate category)
        {
            if (!ModelState.IsValid) return BadRequest(category);
            if (await _categoryService.CreateCategory(category))
                return RedirectToAction(nameof(Index));
            else
                return View(category);
        }
    }
}