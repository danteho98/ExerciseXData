using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace foodXData.Controllers
{
    public class FoodsController : Controller
    {
        private readonly AppDbContext _context;
        public FoodsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Foods> objFoodsList = _context.Foods;
            /*Select statement is not needed here as _context.Foods will get all the categories from table*/

            return View(objFoodsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Foods obj)
        {
            if (ModelState.IsValid)
            {
                _context.Foods.Add(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Foods created successfully";
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
            var categories = _context.Foods.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(Foods obj)
        {
            if (ModelState.IsValid)
            {
                _context.Foods.Update(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Foods updated successfully";
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
            var categories = _context.Foods.Find(id); //find if used for finding the primary key of the table
            //var categoriesFirst= _context.Foods.FirstOrDefault(u=>u.Id==id);
            //var categoriesSingle = _context.Foods.SingleOrDefault(u => u.Id == id);

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //POST
        [HttpPost] //ActionName can be used to name explicitly for the delete page
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Foods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Foods.Remove(obj); //items input from user
            _context.SaveChanges(); //Save the items to the database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}