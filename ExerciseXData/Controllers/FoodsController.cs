using Microsoft.AspNetCore.Mvc;
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using ExerciseXData_DietLibrary.DataTransferObject;
using Microsoft.EntityFrameworkCore;
namespace ExerciseXData.Controllers
{
    [Route("admin/foods")]
    public class FoodsController : Controller
    {
        private readonly DietDbContext _dietDbContext;

        public FoodsController(DietDbContext foodDbContext)
        {
            _dietDbContext = foodDbContext;
        }

        // GET: admin/foods
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // Fetch foods and their associated foods with additional properties
            var foods = await _dietDbContext.Foods.ToListAsync();
            var foodsFoods = await _dietDbContext.DietsFoods
                .Include(df => df.Diets) // Include the food entity
                .Include(df => df.Foods)  // Include the food entity
                .ToListAsync();

            var model = new FoodIndexDto
            {
                Foods = foods,
                DietsFoods = foodsFoods
            };

            return View(model);
        }

        // GET: admin/foods/create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            // Return an empty DTO for the Create form
            return View(new CreateFoodDto());
        }

        // POST: admin/foods/create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFoodDto foodDto)
        {
            // Validate the submitted data
            if (ModelState.IsValid)
            {
                // Map DTO to the Diet model
                var food = new FoodsModel
                {
                    F_Image = foodDto.F_Image ?? Array.Empty<byte>(), // Assuming byte[] for images
                    F_Name = foodDto.F_Name ?? string.Empty,
                    F_Group = foodDto.F_Group ?? string.Empty,
                    F_Calories = foodDto.F_Calories ?? 0
               
                };

                // Add to database and save changes
                _dietDbContext.Foods.Add(food);
                await _dietDbContext.SaveChangesAsync();

                TempData["success"] = "Food created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, return to the form with the provided data
            return View(foodDto);
        }

        // GET: admin/foods/edit/{id}
        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Find the food by ID
            var food = await _dietDbContext.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            // Map the model to an Edit DTO
            var foodDto = new EditFoodDto
            {
                F_Id = food.F_Id,
                F_Image = food.F_Image,
                F_Name = food.F_Name ,
                F_Group = food.F_Group ,
                F_Calories = food.F_Calories 
            };

            return View(foodDto);
        }

        // POST: admin/foods/edit/{id}
        // POST: Admin/Diets/Edit/{id}
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditFoodDto foodDto)
        {
            if (id != foodDto.F_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update the Diet model
                var food = await _dietDbContext.Foods.FindAsync(id);
                if (food == null)
                {
                    return NotFound();
                }

                food.F_Image = foodDto.F_Image ?? food.F_Image; // Retain original image if no new one is provided
                food.F_Name = foodDto.F_Name ?? string.Empty;
                food.F_Group = foodDto.F_Group ?? string.Empty;
                food.F_Calories = foodDto.F_Calories ?? food.F_Calories; // Retain original if no value provided


                // Save changes to the database
                _dietDbContext.Foods.Update(food);
                await _dietDbContext.SaveChangesAsync();

                TempData["success"] = "Diet updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, return to the form
            return View(foodDto);
        }

        // GET: admin/foods/delete/{id}
        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the diet by ID
            var food = await _dietDbContext.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: admin/foods/delete/{id}
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSuccess(int id)
        {
            var food = await _dietDbContext.Foods.FindAsync(id);
            if (food != null)
            {
                // Remove the diet from the database
                _dietDbContext.Foods.Remove(food);
                await _dietDbContext.SaveChangesAsync();
            }

            TempData["success"] = "Diet deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }

}