using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_ExerciseLibrary.Interface;
using ExerciseXData_ExerciseLibrary.Models;
using ExerciseXData_ExerciseLibrary.Repositories;
using ExerciseXData_ExerciseLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    //[Authorize(Roles = "Admin")]

    [Route("admin/exercise-categories")]
    public class CategoriesController : Controller
    {
        //private readonly ICategoryRepository _categoryRepository;
        //private readonly CategoryService _categoryService;
        private readonly ExerciseDbContext _exerciseDbContext;

        // Constructor injecting the category repository
        public CategoriesController(/*ICategoryRepository categoryRepository, CategoryService categoryService,*/ ExerciseDbContext exerciseDbContext)
        {
            //_categoryRepository = categoryRepository;
            //_categoryService = categoryService;
            _exerciseDbContext = exerciseDbContext;
        }

        // GET: Categories
        public IActionResult Index()
        {
            IEnumerable<CategoriesModel> objCategoryList = _exerciseDbContext.Categories;
            /*Select statement is not needed here as _db.Category will get all the categories from table*/

            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Create(CategoriesModel obj)
        {

            if (ModelState.IsValid)
            {
                _exerciseDbContext.Categories.Add(obj); //items input from user
                _exerciseDbContext.SaveChanges(); //Save the items to the database
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(obj);
        }

        //get
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
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(CategoriesModel obj)
        {
          
            if (ModelState.IsValid)
            {
                _exerciseDbContext.Categories.Update(obj); //items input from user
                _exerciseDbContext.SaveChanges(); //Save the items to the database
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
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

        //POST
        [HttpPost] //ActionName can be used to name explicitly for the delete page
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult DeletePOST(int? id)
        {
            var obj = _exerciseDbContext.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _exerciseDbContext.Categories.Remove(obj); //items input from user
            _exerciseDbContext.SaveChanges(); //Save the items to the database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}