using ExerciseXData.Data;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using ExerciseXDataLibrary.Data;
using ExerciseXDataLibrary.Models;

public class ExercisesController : Controller
{
    private readonly ExerciseDbContext _exerciseDbContext;

    public ExercisesController(ExerciseDbContext context)
    {
        _exerciseDbContext = context;
    }

    // READ (GET): List all exercises
    public async Task<IActionResult> Index()
    {
        var exercises = _exerciseDbContext.Exercises.Include(e => e.Categories);
        return View(await exercises.ToListAsync());
    }

    // CREATE (GET): Show the form to create a new exercise
    public IActionResult Create()
    {
        ViewBag.Categories = _exerciseDbContext.Categories.ToList();
        return View();
    }

    // CREATE (POST): Save a new exercise to the database
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("E_Id, C_Id, E_Image, E_Name, E_Description, E_Pros_1, E_Pros_2, E_Pros_3, " +
        "E_Cons_1, E_Cons_2, E_Cons_3, E_Modified_Date")]  ExercisesModel exercise)
    {
        if (ModelState.IsValid)
        {
            _exerciseDbContext.Add(exercise);
            await _exerciseDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = _exerciseDbContext.Categories.ToList();
        return View(exercise);
    }

    // UPDATE (GET): Show the form to edit an exercise
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exercise = await _exerciseDbContext.Exercises.FindAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        ViewBag.Categories = _exerciseDbContext.Categories.ToList();
        return View(exercise);
    }

    // UPDATE (POST): Save the edited exercise back to the database
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("E_Id, C_Id, E_Image, E_Name, E_Description, E_Pros_1, E_Pros_2, E_Pros_3, " +
        "E_Cons_1, E_Cons_2, E_Cons_3, E_Modified_Date")] ExercisesModel exercise)
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
                if (!ExerciseExists(exercise.E_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = _exerciseDbContext.Categories.ToList();
        return View(exercise);
    }

    // DELETE (GET): Show a confirmation page for deleting an exercise
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exercise = await _exerciseDbContext.Exercises
            .Include(e => e.Categories)
            .FirstOrDefaultAsync(m => m.C_Id == id);
        if (exercise == null)
        {
            return NotFound();
        }

        return View(exercise);
    }

    // DELETE (POST): Remove the exercise from the database
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var exercise = await _exerciseDbContext.Exercises.FindAsync(id);
        _exerciseDbContext.Exercises.Remove(exercise);
        await _exerciseDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ExerciseExists(int id)
    {
        return _exerciseDbContext.Exercises.Any(e => e.E_Id == id);
    }
}
