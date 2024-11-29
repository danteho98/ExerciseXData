using Microsoft.AspNetCore.Mvc;
using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Services;
using ExerciseXData_ExerciseLibrary.Interface;

public class ExercisesController : Controller
{
    private readonly IExercisesService _exerciseService;

    public ExercisesController(IExercisesService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    public async Task<IActionResult> Index()
    {
        var exercises = await _exerciseService.GetAllExercisesAsync();
        return View(exercises);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExercisesModel exercise)
    {
        if (ModelState.IsValid)
        {
            await _exerciseService.AddExerciseAsync(exercise);
            return RedirectToAction(nameof(Index));
        }
        return View(exercise);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var exercise = await _exerciseService.GetExerciseByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        return View(exercise);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ExercisesModel exercise)
    {
        if (ModelState.IsValid)
        {
            await _exerciseService.UpdateExerciseAsync(exercise);
            return RedirectToAction(nameof(Index));
        }
        return View(exercise);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var exercise = await _exerciseService.GetExerciseByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        return View(exercise);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _exerciseService.DeleteExerciseAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
