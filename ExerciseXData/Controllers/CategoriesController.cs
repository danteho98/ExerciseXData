using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseXData.Data;
using ExerciseXData.Models;
using System.Threading.Tasks;
using ExerciseXDataLibrary.Data;

namespace ExerciseXData.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ExerciseDbContext _exerciseContext;
        public CategoriesController(ExerciseDbContext exerciseContext)
        {
            _exerciseContext = exerciseContext;
        }

        public IActionResult Index()
        {
            IEnumerable<CategoriesModel> objCategoriesList = _exerciseContext.Categories;
            /*Select statement is not needed here as _exerciseContext.Categories will get all the categories from table*/

            return View(objCategoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("C_Id, C_Image, C_Name, C_Modified_Date")] CategoriesModel category)
        {
            if (ModelState.IsValid)
            {
                _exerciseContext.Add(category);
                await _exerciseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // UPDATE (GET): Show the form to edit a category
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _exerciseContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // UPDATE (POST): Save the edited category back to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("C_Id, C_Image, C_Name, C_Modified_Date")] CategoriesModel category)
        {
            if (id != category.C_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _exerciseContext.Update(category);
                    await _exerciseContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.C_Id))
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
            return View(category);
        }

        // DELETE (GET): Show a confirmation page for deleting a category
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _exerciseContext.Categories
                .FirstOrDefaultAsync(m => m.C_Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // DELETE (POST): Remove the category from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _exerciseContext.Categories.FindAsync(id);
            _exerciseContext.Categories.Remove(category);
            await _exerciseContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _exerciseContext.Categories.Any(e => e.C_Id == id);
        }
    }
}

