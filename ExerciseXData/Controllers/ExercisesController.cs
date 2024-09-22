using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _service;

        public ExerciseController(IExerciseService service)
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
            [Bind("C_ID, C_Image, E_Name, E_Pros_1, E_Pros_2, E_Pros_3, E_Cons_1, E_Cons_2, E_Cons_3, E_Modified_Date")] Exercises exercise)
        {
            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            await _service.AddAsync(exercise);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var exerciseDetails = await _service.GetByIdAsync(id);

            if (exerciseDetails == null) return View("NotFound");
            return View(exerciseDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var exerciseDetails = await _service.GetByIdAsync(id);

            if (exerciseDetails == null) return View("NotFound");
            return View(exerciseDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,
            [Bind("C_ID, C_Image, E_Name, E_Pros_1, E_Pros_2, E_Pros_3, E_Cons_1, E_Cons_2, E_Cons_3, E_Modified_Date")] Exercises exercise)
        {
            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            await _service.UpdateAsync(id, exercise);
            return RedirectToAction(nameof(Index));
        }

        //Get: 
        public async Task<IActionResult> Delete(int id)
        {
            var exerciseDetails = await _service.GetByIdAsync(id);

            if (exerciseDetails == null) return View("NotFound");
            return View(exerciseDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id,
            [Bind("C_ID, C_Image, E_Name, E_Pros_1, E_Pros_2, E_Pros_3, E_Cons_1, E_Cons_2, E_Cons_3, E_Modified_Date")] Exercises exercise)
        {
            var exerciseDetails = await _service.GetByIdAsync(id);

            if (exerciseDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}