using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseXData.Data;
using ExerciseXData.Models;
using System.Threading.Tasks;

namespace ExerciseXData.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Categories> objCategoriesList = _context.Categories;
            /*Select statement is not needed here as _context.Categories will get all the categories from table*/

            return View(objCategoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categories obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Categories created successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categories = _context.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(Categories obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Categories updated successfully";
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
            var categories = _context.Categories.Find(id); //find if used for finding the primary key of the table
            //var categoriesFirst= _context.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoriesSingle = _context.Categories.SingleOrDefault(u => u.Id == id);

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //POST
        [HttpPost] //ActionName can be used to name explicitly for the delete page
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult DeletePOST(int ? id)
        {
            var obj = _context.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj); //items input from user
            _context.SaveChanges(); //Save the items to the database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}
