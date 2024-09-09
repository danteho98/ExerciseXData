using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("C_Image, C_Name")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            
            await _service.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var cateogryDetails = await _service.GetByIdAsync(id);
            if (cateogryDetails == null) return View("Empty");
            return View(cateogryDetails);
        }

        public async Task<IActionResult> Edit(int id)
        { 
            var cateogryDetails = await _service.GetByIdAsync(id);
            if (cateogryDetails == null) return View("NotFound");
            return View(cateogryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("C_Image, C_Name")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            
            await _service.UpdateAsync(id, category);
            return RedirectToAction(nameof(Index));
        }

            //Get: 
        public async Task<IActionResult> Delete(int id)
        {
            var cateogryDetails = await _service.GetByIdAsync(id);
            if (cateogryDetails == null) return View("NotFound");
            return View(cateogryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("C_Image, C_Name")] Category category)
        {
            var cateogryDetails = await _service.GetByIdAsync(id);
            if (cateogryDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
