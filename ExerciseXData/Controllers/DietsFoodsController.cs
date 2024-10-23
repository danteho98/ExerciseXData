using ExerciseXData.Data;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class DietsFoodsController : Controller
    {
        private readonly AppDbContext _context;
        public DietsFoodsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<DietsFoods> objDietsFoodsList = _context.DietsFoods;
            /*Select statement is not needed here as _context.DietsFoods will get all the categories from table*/

            return View(objDietsFoodsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DietsFoods obj)
        {
            if (ModelState.IsValid)
            {
                _context.DietsFoods.Add(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "DietsFoods created successfully";
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
            var categories = _context.DietsFoods.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(DietsFoods obj)
        {
            if (ModelState.IsValid)
            {
                _context.DietsFoods.Update(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "DietsFoods updated successfully";
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
            var categories = _context.DietsFoods.Find(id); //find if used for finding the primary key of the table
            //var categoriesFirst= _context.DietsFoods.FirstOrDefault(u=>u.Id==id);
            //var categoriesSingle = _context.DietsFoods.SingleOrDefault(u => u.Id == id);

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
            var obj = _context.DietsFoods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.DietsFoods.Remove(obj); //items input from user
            _context.SaveChanges(); //Save the items to the database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}
