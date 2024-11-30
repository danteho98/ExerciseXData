using Microsoft.AspNetCore.Mvc;
using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Services;
using ExerciseXData_ExerciseLibrary.Interface;
using Microsoft.EntityFrameworkCore;
using ExerciseXData_ExerciseLibrary.Data;

[Route("admin/exercise")]
public class ExercisesController : Controller
{
    private readonly ExerciseDbContext _exerciseDbContext;

    public ExercisesController(ExerciseDbContext exerciseDbContext)
    {
        _exerciseDbContext = exerciseDbContext;
    }

    // GET: Exercises for a specific Category
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> Index(int categoryId)
    {
        var category = await _exerciseDbContext.Categories
            .Include(c => c.Exercises)  // Load exercises for the category
            .FirstOrDefaultAsync(c => c.C_Id == categoryId);

        if (category == null)
        {
            return NotFound();
        }

        ViewData["CategoryId"] = categoryId; // Set the categoryId for use in the view

        return View(category.Exercises); // Pass the exercises to the view
    }

    // GET: Exercise/Create for a specific Category
    [HttpGet("Create")]
    public IActionResult Create(int categoryId)
    {
        var category = _exerciseDbContext.Categories.FirstOrDefault(c => c.C_Id == categoryId);
        if (category == null)
        {
            return NotFound();
        }

        var model = new ExercisesModel
        {
            CategoriesC_Id = categoryId // Associate the new exercise with the category
        };

        return View(model);
    }

    // POST: Exercise/Create
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExercisesModel exercise)
    {
        if (ModelState.IsValid)
        {
            var category = await _exerciseDbContext.Categories.FirstOrDefaultAsync(c => c.C_Id == exercise.CategoriesC_Id);
            if (category == null)
            {
                return NotFound();
            }

            _exerciseDbContext.Exercises.Add(exercise); // Add new exercise to the database
            await _exerciseDbContext.SaveChangesAsync();

            TempData["success"] = "Exercise added successfully!";
            return RedirectToAction(nameof(Index), new { categoryId = exercise.CategoriesC_Id });
        }

        return View(exercise);
    }

    // GET: Exercise/Edit for a specific Exercise
    [HttpGet("Edit/{id:int}")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exercise = await _exerciseDbContext.Exercises
            .FirstOrDefaultAsync(e => e.E_Id == id);

        if (exercise == null)
        {
            return NotFound();
        }

        return View(exercise);
    }

    // POST: Exercise/Edit
    [HttpPost("Edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ExercisesModel exercise)
    {
        if (id != exercise.E_Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _exerciseDbContext.Update(exercise);
                await _exerciseDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_exerciseDbContext.Exercises.Any(e => e.E_Id == exercise.E_Id))
                {
                    return NotFound();
                }
                throw;
            }

            TempData["success"] = "Exercise updated successfully!";
            return RedirectToAction(nameof(Index), new { categoryId = exercise.CategoriesC_Id });
        }

        return View(exercise);
    }

    // GET: Exercise/Delete for a specific Exercise
    [HttpGet("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exercise = await _exerciseDbContext.Exercises
            .FirstOrDefaultAsync(e => e.E_Id == id);

        if (exercise == null)
        {
            return NotFound();
        }

        return View(exercise);
    }

    // POST: Exercise/Delete
    [HttpPost("Delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var exercise = await _exerciseDbContext.Exercises.FindAsync(id);
        if (exercise != null)
        {
            _exerciseDbContext.Exercises.Remove(exercise);
            await _exerciseDbContext.SaveChangesAsync();
        }

        TempData["success"] = "Exercise deleted successfully!";
        return RedirectToAction(nameof(Index), new { categoryId = exercise?.CategoriesC_Id });
    }
}
