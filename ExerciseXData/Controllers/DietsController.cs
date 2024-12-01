using Microsoft.AspNetCore.Mvc;
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using ExerciseXData_DietLibrary.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Controllers
{
    [Route("admin/diets")]
    public class DietsController : Controller
    {
        private readonly DietDbContext _dietDbContext;

        public DietsController(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

        // GET: Admin/Diets/Index
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // Fetch diets and their associated foods with additional properties
            var diets = await _dietDbContext.Diets.ToListAsync();
            var dietsFoods = await _dietDbContext.DietsFoods
                .Include(df => df.Diets) // Include the diet entity
                .Include(df => df.Foods)  // Include the food entity
                .ToListAsync();

            var model = new DietIndexDto
            {
                Diets = diets,
                DietsFoods = dietsFoods
            };

            return View(model);
        }

        // GET: Admin/Diets/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            // Return an empty DTO for the Create form
            return View(new CreateDietDto());
        }

        // POST: Admin/Diets/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDietDto dietDto)
        {
            // Validate the submitted data
            if (ModelState.IsValid)
            {
                // Map DTO to the Diet model
                var diet = new DietsModel
                {
                    D_Name = dietDto.D_Name,
                    D_Description = dietDto.D_Description ?? string.Empty,
                    D_Pros_1 = dietDto.D_Pros_1 ?? string.Empty,
                    D_Pros_2 = dietDto.D_Pros_2 ?? string.Empty,
                    D_Pros_3 = dietDto.D_Pros_3 ?? string.Empty,
                    D_Cons_1 = dietDto.D_Cons_1 ?? string.Empty,
                    D_Cons_2 = dietDto.D_Cons_2 ?? string.Empty,
                    D_Cons_3 = dietDto.D_Cons_3 ?? string.Empty
                };

                // Add to database and save changes
                _dietDbContext.Diets.Add(diet);
                await _dietDbContext.SaveChangesAsync();

                TempData["success"] = "Diet created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, return to the form with the provided data
            return View(dietDto);
        }

        // GET: Admin/Diets/Edit/{id}
        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Find the diet by ID
            var diet = await _dietDbContext.Diets.FindAsync(id);
            if (diet == null)
            {
                return NotFound();
            }

            // Map the model to an Edit DTO
            var dietDto = new EditDietDto
            {
                D_Id = diet.D_Id,
                D_Name = diet.D_Name,
                D_Description = diet.D_Description,
                D_Pros_1 = diet.D_Pros_1,
                D_Pros_2 = diet.D_Pros_2,
                D_Pros_3 = diet.D_Pros_3,
                D_Cons_1 = diet.D_Cons_1,
                D_Cons_2 = diet.D_Cons_2,
                D_Cons_3 = diet.D_Cons_3
            };

            return View(dietDto);
        }

        // POST: Admin/Diets/Edit/{id}
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditDietDto dietDto)
        {
            if (id != dietDto.D_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update the Diet model
                var diet = await _dietDbContext.Diets.FindAsync(id);
                if (diet == null)
                {
                    return NotFound();
                }

                diet.D_Name = dietDto.D_Name;
                diet.D_Description = dietDto.D_Description ?? string.Empty;
                diet.D_Pros_1 = dietDto.D_Pros_1 ?? string.Empty;
                diet.D_Pros_2 = dietDto.D_Pros_2 ?? string.Empty;
                diet.D_Pros_3 = dietDto.D_Pros_3 ?? string.Empty;
                diet.D_Cons_1 = dietDto.D_Cons_1 ?? string.Empty;
                diet.D_Cons_2 = dietDto.D_Cons_2 ?? string.Empty;
                diet.D_Cons_3 = dietDto.D_Cons_3 ?? string.Empty;

                // Save changes to the database
                _dietDbContext.Diets.Update(diet);
                await _dietDbContext.SaveChangesAsync();

                TempData["success"] = "Diet updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, return to the form
            return View(dietDto);
        }

        // GET: Admin/Diets/Delete/{id}
        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the diet by ID
            var diet = await _dietDbContext.Diets.FindAsync(id);
            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // POST: Admin/Diets/Delete/{id}
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSuccess(int id)
        {
            var diet = await _dietDbContext.Diets.FindAsync(id);
            if (diet != null)
            {
                // Remove the diet from the database
                _dietDbContext.Diets.Remove(diet);
                await _dietDbContext.SaveChangesAsync();
            }

            TempData["success"] = "Diet deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
