using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_ExerciseLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    //[Authorize(Roles = "Admin")]

    [Route("admin/exercise-categories")]
    public class CategoriesController : Controller
    {
        private readonly ExerciseDbContext _exerciseDbContext;

        public CategoriesController( ExerciseDbContext exerciseDbContext)
        {
            
            _exerciseDbContext = exerciseDbContext;
        }

        // GET: Categories
        [HttpGet("")]
        public IActionResult Index()
        {
            List<CategoriesModel> categoryCategoryList = _exerciseDbContext.Categories.ToList();
            /*Select statement is not needed here as _db.Category will get all the categories from table*/

            return View(categoryCategoryList);
        }

        //GET
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost("Create")]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Create(CategoriesModel category)
        {

            if (ModelState.IsValid)
            {
                _exerciseDbContext.Categories.Add(category); //items input from user
                _exerciseDbContext.SaveChanges(); //Save the items to the database
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(category);
        }

        //get
        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _exerciseDbContext.Categories.Find(id); //find if used for finding the primary key of the table
            //var categoryFromDbFirst= _db.Category.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Category.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //post
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(CategoriesModel category)
        {
            if (!_exerciseDbContext.Categories.Any(c => c.C_Id == category.C_Id))
            {
                ModelState.AddModelError("", "Invalid Category ID.");
                return View(category);
            }

            if (ModelState.IsValid)
            {
                _exerciseDbContext.Categories.Update(category); //items input from user
                _exerciseDbContext.SaveChanges(); //Save the items to the database
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(category);
        }

        //Get
        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _exerciseDbContext.Categories.Find(id); //find if used for finding the primary key of the table

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost("Delete/{id:int}")] //ActionName can be used to name explicitly for the delete page
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult DeleteSuccess(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _exerciseDbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _exerciseDbContext.Categories.Remove(category); //items input from user
            _exerciseDbContext.SaveChanges(); //Save the items to the database

            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}