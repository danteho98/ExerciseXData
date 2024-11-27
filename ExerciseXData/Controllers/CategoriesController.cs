using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_ExerciseLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Manage()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoriesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Manage", await _categoryService.GetAllCategoriesAsync());
            }

            await _categoryService.AddCategoryAsync(model);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoriesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Manage", await _categoryService.GetAllCategoriesAsync());
            }

            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoriesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Manage", await _categoryService.GetAllCategoriesAsync());
            }

            return RedirectToAction("Manage");
        }
    }
}