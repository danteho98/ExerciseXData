using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseXData_SharedLibrary.Models;  // For Users, Diets, Foods, and DietsFoods
using ExerciseXData_ExerciseLibrary.Data; // For DietDbContext
using System.Linq;
using System.Threading.Tasks;
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;

namespace ExerciseXData_ExerciseLibrary.Controllers
{
    [Route("admin/diets")]
    public class DietController : Controller
    {
        private readonly DietDbContext _context;

        public DietController(DietDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Diets
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var diets = await _context.Diets.ToListAsync();
            return View(diets);
        }

        // GET: Admin/Diets/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            // You can pass a list of available foods to associate with the diet
            ViewBag.Foods = _context.Foods.ToList();
            return View();
        }

        // POST: Admin/Diets/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DietsModel diet, int[] selectedFoodIds)
        {
            if (ModelState.IsValid)
            {
                // Add the diet to the database
                _context.Diets.Add(diet);
                await _context.SaveChangesAsync();

                // Add selected foods to the Diet
                if (selectedFoodIds != null)
                {
                    foreach (var foodId in selectedFoodIds)
                    {
                        var dietFood = new DietsFoodsModel
                        {
                            DietsD_Id = diet.D_Id,
                            FoodsF_Id = foodId
                        };
                        _context.DietsFoods.Add(dietFood);
                    }
                    await _context.SaveChangesAsync();
                }

                TempData["success"] = "Diet created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If model state is not valid, return to the view with foods
            ViewBag.Foods = _context.Foods.ToList();
            return View(diet);
        }

        // GET: Admin/Diets/Edit/5
        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var diet = await _context.Diets
                .FirstOrDefaultAsync(d => d.D_Id == id);

            if (diet == null)
            {
                return NotFound();
            }

            // Fetch the foods already associated with the diet
            var dietFoods = await _context.DietsFoods
                .Where(df => df.DietsD_Id == id)
                .Select(df => df.FoodsF_Id)
                .ToListAsync();

            ViewBag.SelectedFoods = dietFoods;

            // Provide list of foods to choose from
            ViewBag.Foods = await _context.Foods.ToListAsync();

            return View(diet);
        }

        // POST: Admin/Diets/Edit/5
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DietsModel diet, int[] selectedFoodIds)
        {
            if (id != diet.D_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diet);
                    await _context.SaveChangesAsync();

                    // Remove previous associations
                    var existingDietFoods = await _context.DietsFoods
                        .Where(df => df.DietsD_Id == id)
                        .ToListAsync();

                    _context.DietsFoods.RemoveRange(existingDietFoods);

                    // Add new associations
                    if (selectedFoodIds != null)
                    {
                        foreach (var foodId in selectedFoodIds)
                        {
                            var dietFood = new DietsFoodsModel
                            {
                                DietsD_Id = diet.D_Id,
                                FoodsF_Id = foodId
                            };
                            _context.DietsFoods.Add(dietFood);
                        }
                    }

                    await _context.SaveChangesAsync();
                    TempData["success"] = "Diet updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietExists(diet.D_Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }

            // If model state is not valid, return the view with foods
            ViewBag.Foods = _context.Foods.ToList();
            return View(diet);
        }

        // GET: Admin/Diets/Delete/5
        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var diet = await _context.Diets
                .FirstOrDefaultAsync(d => d.D_Id == id);

            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // POST: Admin/Diets/Delete/5
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diet = await _context.Diets.FindAsync(id);

            if (diet != null)
            {
                _context.Diets.Remove(diet);
                await _context.SaveChangesAsync();
            }

            TempData["success"] = "Diet deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool DietExists(int id)
        {
            return _context.Diets.Any(e => e.D_Id == id);
        }
    }
}
