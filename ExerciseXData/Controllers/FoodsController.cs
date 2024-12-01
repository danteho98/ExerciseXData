using ExerciseXData.Data;
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace foodXData.Controllers
{
    public class FoodsController : Controller
    {
        private readonly DietDbContext _dietDbContext;

        public FoodsController(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

        // GET: admin/foods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var foods = await _dietDbContext.Foods.ToListAsync();
            return View(foods); // Ensure you have an Index view for listing foods
        }

        // GET: admin/foods/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(); // Ensure you have a Create view with a form for creating food
        }

        // POST: admin/foods/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodsModel food)
        {
            if (ModelState.IsValid)
            {
                _dietDbContext.Foods.Add(food);
                await _dietDbContext.SaveChangesAsync();
                TempData["success"] = "Food created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: admin/foods/edit/{id}
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var food = await _dietDbContext.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food); // Ensure you have an Edit view
        }

        // POST: admin/foods/edit/{id}
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FoodsModel food)
        {
            if (id != food.F_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dietDbContext.Update(food);
                    await _dietDbContext.SaveChangesAsync();
                    TempData["success"] = "Food updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dietDbContext.Foods.Any(f => f.F_Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }
            return View(food);
        }

        // GET: admin/foods/delete/{id}
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _dietDbContext.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food); // Ensure you have a Delete confirmation view
        }

        // POST: admin/foods/delete/{id}
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await _dietDbContext.Foods.FindAsync(id);
            if (food != null)
            {
                _dietDbContext.Foods.Remove(food);
                await _dietDbContext.SaveChangesAsync();
                TempData["success"] = "Food deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }

}