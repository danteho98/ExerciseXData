using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class DietController : Controller
    {
        private readonly IDietService _service;

        public DietController(IDietService service)
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
        public async Task<IActionResult> Create(
            [Bind(" D_Name, D_Description, D_Pros_1, D_Pros_2, D_Pros_3, D_Cons_1, D_Cons_2, D_Cons_3", "D_Modified_Date")] Diets diet)
        {
            if (!ModelState.IsValid)
            {
                return View(diet);
            }

            await _service.AddAsync(diet);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var dietDetails = await _service.GetByIdAsync(id);

            if (dietDetails == null) return View("Empty");
            return View(dietDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dietDetails = await _service.GetByIdAsync(id);

            if (dietDetails == null) return View("NotFound");
            return View(dietDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,
            [Bind("C_ID, C_Image, E_Name, E_Pros_1, E_Pros_2, E_Pros_3, E_Cons_1, E_Cons_2, E_Cons_3", "D_Modified_Date")] Diets diet)
        {
            if (!ModelState.IsValid)
            {
                return View(diet);
            }

            await _service.UpdateAsync(id, diet);
            return RedirectToAction(nameof(Index));
        }

        //Get: 
        public async Task<IActionResult> Delete(int id)
        {
            var dietDetails = await _service.GetByIdAsync(id);

            if (dietDetails == null) return View("NotFound");
            return View(dietDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id,
            [Bind("C_ID, C_Image, E_Name, E_Pros_1, E_Pros_2, E_Pros_3, E_Cons_1, E_Cons_2, E_Cons_3", "D_Modified Date")] Diets diet)
        {
            var dietDetails = await _service.GetByIdAsync(id);

            if (dietDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}