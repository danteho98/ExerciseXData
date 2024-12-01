//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using ExerciseXData_ExerciseLibrary.Models;
//using ExerciseXData_DietLibrary.Data;
//using ExerciseXData_DietLibrary.Models;
//using ExerciseXData_DietLibrary.DataTransferObject;

//namespace ExerciseXData.Controllers
//{
//    [Route("admin/dietsfoods")]
//    public class DietsFoodsController : Controller
//    {
//        private readonly DietDbContext _dietDbContext;

//        public DietsFoodsController(DietDbContext dietDbContext)
//        {
//            _dietDbContext = dietDbContext;
//        }

//        [HttpGet("Index")]
//        public async Task<IActionResult> Index()
//        {
//            // Fetch diets and their associated foods with additional properties
//            var diets = await _dietDbContext.Diets.ToListAsync();
//            var dietsFoods = await _dietDbContext.DietsFoods
//                .Include(df => df.Diets) // Include the diet entity
//                .Include(df => df.Foods)  // Include the food entity
//                .ToListAsync();

//            var model = new DietIndexDto
//            {
//                Diets = diets,
//                DietsFoods = dietsFoods
//            };

//            return View(model);
//        }


//        // GET: List all foods for a specific diet
//        [HttpGet("diet/{dietId}")]
//        public async Task<IActionResult> GetFoodsForDiet(int dietId)
//        {
//            var foods = await _dietDbContext.DietsFoods
//                .Where(df => df.DF_Id == dietId)
//                .Select(df => df.Foods)
//                .ToListAsync();

//            return View(foods); // Ensure you have a view to display the foods for this diet
//        }

//        // POST: Associate food with a diet
//        [HttpPost("create")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> AddFoodToDiet(int foodId, int dietId)
//        {
//            if (!_dietDbContext.Foods.Any(f => f.F_Id == foodId) || !_dietDbContext.Diets.Any(d => d.D_Id == dietId))
//            {
//                return NotFound();
//            }

//            var exists = await _dietDbContext.DietsFoods
//                .AnyAsync(df => df.FoodsF_Id == foodId && df.DietsD_Id == dietId);

//            if (!exists)
//            {
//                _dietDbContext.DietsFoods.Add(new DietsFoodsModel
//                {
//                    FoodsF_Id = foodId,
//                    DietsD_Id = dietId
//                });

//                await _dietDbContext.SaveChangesAsync();
//                TempData["success"] = "Food successfully added to diet!";
//            }

//            return RedirectToAction("Index");
//        }

//        // POST: Remove food from a diet
//        [HttpPost("delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> RemoveFoodFromDiet(int foodId, int dietId)
//        {
//            var dietFood = await _dietDbContext.DietsFoods
//                .FirstOrDefaultAsync(df => df.FoodsF_Id == foodId && df.DietsD_Id == dietId);

//            if (dietFood != null)
//            {
//                _dietDbContext.DietsFoods.Remove(dietFood);
//                await _dietDbContext.SaveChangesAsync();
//                TempData["success"] = "Food successfully removed from diet!";
//            }

//            return RedirectToAction("Index");
//        }
//    }
//}