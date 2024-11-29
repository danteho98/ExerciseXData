using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;



namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        // Constructor injecting the category repository
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            // Retrieve all categories from the repository
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories); // Pass categories to the view
        }

        // GET: Categories/Add
        public IActionResult Add()
        {
            return View(); // Render the Add view
        }

        // POST: Categories/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoriesModel model, IFormFile C_Image)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload (optional)
                if (C_Image != null && C_Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await C_Image.CopyToAsync(memoryStream);
                        model.C_Image = memoryStream.ToArray();
                    }
                }

                // Save the new category
                await _categoryRepository.AddAsync(model);
                await _categoryRepository.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect to the category list
            }

            return View(model); // If model is invalid, show the form with validation errors
        }

        // GET: Categories/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(); // If category not found, return 404
            }
            return View(category); // Pass the category to the Edit view
        }

        // POST: Categories/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriesModel model, IFormFile C_Image)
        {
            if (id != model.C_Id)
            {
                return BadRequest(); // If the ID doesn't match, return a bad request
            }

            if (ModelState.IsValid)
            {
                // Handle file upload if a new image is provided
                if (C_Image != null && C_Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await C_Image.CopyToAsync(memoryStream);
                        model.C_Image = memoryStream.ToArray();
                    }
                }

                // Update the category
                 _categoryRepository.UpdateAsync(model);
                await _categoryRepository.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect back to the category list
            }

            return View(model); // If model is invalid, show the form with validation errors
        }

        // GET: Categories/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(); // If category not found, return 404
            }
            return View(category); // Pass the category to the Delete confirmation view
        }

        // POST: Categories/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                // Delete the category
                _categoryRepository.DeleteAsync(category);
                await _categoryRepository.SaveChangesAsync();
            }

            return RedirectToAction("Index"); // Redirect back to the category list
        }
    }
}