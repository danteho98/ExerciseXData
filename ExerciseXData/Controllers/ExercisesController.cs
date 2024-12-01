using Microsoft.AspNetCore.Mvc;
using ExerciseXData_ExerciseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_ExerciseLibrary.DataTransferObject;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

[Route("admin/exercise")]
public class ExercisesController : Controller
{
    private readonly ExerciseDbContext _exerciseDbContext;
    private readonly ILogger<ExercisesController> _logger;

    public ExercisesController(ExerciseDbContext exerciseDbContext, ILogger<ExercisesController> logger)
    {
        _exerciseDbContext = exerciseDbContext;
        _logger = logger;
    }

    // GET: Exercises for a specific Category
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        // Retrieve all categories
        var categories = await _exerciseDbContext.Categories.ToListAsync();  
        // Retrieve all exercises
        var exercises = await _exerciseDbContext.Exercises
            .Include(e => e.Categories) // Assuming you have a relationship with Categories
            .ToListAsync();

        var model = new ExerciseIndexDto
        {
            Exercises = exercises,
            Categories = categories
        };
        //if (categories == null || !categories.Any())
        //{
        //    // Optionally, you can log or show an error if no categories are found
        //    // Log.Error("No categories found in the database");
        //    // Or add an error to ModelState to indicate a problem
        //    ModelState.AddModelError("", "No categories found in the database.");
        //    return View(new List<ExercisesModel>());
        //}

        //// Pass the list of categories to the view using ViewBag
        //ViewBag.Categories =  new SelectList(categories, "Id", "Name"); //categories;
        //ViewBag.Exercises = exercises;  // Pass the list of exercises to the view

        return View(model);
    }


    // GET: Exercise/Create for a specific Category

    [HttpGet("Create")]
    public IActionResult Create(/*int categoryId = 0*/)
    {
        //var model = new CreateExerciseViewModel();
        //if (categoryId == 0)
        //{
        //    ModelState.AddModelError("", "Invalid category ID.");
        //    return RedirectToAction(nameof(Index)); // Redirect to index if no categoryId is provided
        //}
        // Retrieve categories for the dropdown
        var categories = _exerciseDbContext.Categories.ToList();
        ViewBag.Categories = new SelectList(categories, "C_Id", "C_Name");
        //ViewBag.Categories = new SelectList(_exerciseDbContext.Categories, "C_Id", "C_Name");
        //ViewBag.Categories = new SelectList(_exerciseDbContext.Categories, "C_Id", "C_Name", categoryId);
        // Return the Create view with an empty model
        var model = new CreateExerciseViewModel();
        return View(model);
    }


    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateExerciseViewModel exercises)
    {
        if (ModelState.IsValid)
        {
            // Create a new Exercise from the DTO
            var exercise = new ExercisesModel
            {
                CategoriesC_Id = exercises.CategoriesC_Id,
                E_Image = exercises.E_Image,
                E_Name = exercises.E_Name ?? string.Empty,
                E_Description = exercises.E_Description ?? string.Empty,
                E_Pros_1 = exercises.E_Pros_1 ?? string.Empty,
                E_Pros_2 = exercises.E_Pros_2 ?? string.Empty,
                E_Pros_3 = exercises.E_Pros_3 ?? string.Empty,
                E_Cons_1 = exercises.E_Cons_1 ?? string.Empty,
                E_Cons_2 = exercises.E_Cons_2 ?? string.Empty,
                E_Cons_3 = exercises.E_Cons_3 ?? string.Empty
            };

            // Add the exercise to the database and save changes
            _exerciseDbContext.Exercises.Add(exercise);
            await _exerciseDbContext.SaveChangesAsync();

            TempData["success"] = "Exercise added successfully!";
            return RedirectToAction("Index");/*(nameof(Index)); */ // Redirect to exercise list or other action
        }

        // If model validation fails, re-populate the categories dropdown and return the form
        //ViewBag.Categories = new SelectList(_exerciseDbContext.Categories, "Id", "Name", exercises.CategoriesC_Id);
        return View(exercises); 
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
