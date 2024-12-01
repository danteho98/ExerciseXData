using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    [Route("admin/foods")]
    public class FoodsController : Controller
    {
        private readonly DietDbContext _dietDbContext;

        public FoodsController(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

        // GET: admin/foods
        [HttpGet]
        public IActionResult Index()
        {
            List<FoodsModel> foodsList = _dietDbContext.Foods.ToList();
            /*Select statement is not needed here as _db.Category will get all the categories from table*/

            return View(foodsList);

        }

        // GET: admin/foods/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(); // Ensure you have a Create view with a form for creating food
        }

        // POST: admin/foods/create
        [HttpPost("Create")]
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
        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var foodsFromDb = _dietDbContext.Foods.Find(id); //find if used for finding the primary key of the table
            //var categoryFromDbFirst= _db.Category.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Category.SingleOrDefault(u => u.Id == id);

            if (foodsFromDb == null)
            {
                return NotFound();
            }

            return View(foodsFromDb);
        }

        // POST: admin/foods/edit/{id}
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(FoodsModel food)
        {
            if (!_dietDbContext.Foods.Any(f => f.F_Id == food.F_Id))
            {
                ModelState.AddModelError("", "Invalid Foods ID.");
                return View(food);
            }

            if (ModelState.IsValid)
            {
                _dietDbContext.Foods.Update(food); //items input from user
                _dietDbContext.SaveChanges(); //Save the items to the database
                TempData["success"] = "Food updated successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(food);
        }

        // GET: admin/foods/delete/{id}
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var foodsFromDb = _dietDbContext.Foods.Find(id); //find if used for finding the primary key of the table

            if (foodsFromDb == null)
            {
                return NotFound();
            }

            return View(foodsFromDb);
        }

        // POST: admin/foods/delete/{id}
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSuccess(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var foods = _dietDbContext.Foods.Find(id);
            if (foods == null)
            {
                return NotFound();
            }
            _dietDbContext.Foods.Remove(foods); //items input from user
            _dietDbContext.SaveChanges(); //Save the items to the database

            TempData["success"] = "Food deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")

        }
    }

}