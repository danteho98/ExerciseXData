using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseXData.Data;
using ExerciseXData.Models;
using System.Threading.Tasks;

namespace ExerciseXData.Controllers
{
    public class DietsController : Controller
    {

        private readonly AppDbContext _context;
        public DietsController(AppDbContext context)
        {
            _context = context;
        }

        // Get a user's diet
        //public IActionResult GetUserDiets(int userId)
        //{
        //    var diets = _context.Diets
        //                        .Where(d => d.D_Id == userId)
        //                        .Include(d => d.UsersDiets)
        //                        .ThenInclude(df => df.Diets)
        //                        .ToList();
        //    return View(diets);
        //}

        // Add a food item to a diet
        //[HttpPost]
        //public IActionResult AddFoodToDiet(int dietId, int userId)
        //{
        //    var dietFoodItem = new UsersDiets
        //    {
        //        D_Id = dietId,
        //        U_Id = userId
        //    };
        //    _context.UsersDiets.Add(UsersDiets);
        //    _context.SaveChanges();
        //    return RedirectToAction("GetUserDiets", new { userId = /* Get the current userId */ });
        //}

        //// Remove a food item from a diet
        //[HttpPost]
        //public IActionResult RemoveFoodFromDiet(int dietId, int userId)
        //{
        //    var dietFoodItem = _context.DietFood
        //                               .FirstOrDefault(df => df.D_Id == dietId && df.U_Id == userId);
        //    if (dietFoodItem != null)
        //    {
        //        _context.DietFood.Remove(dietFoodItem);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("GetUserDiets", new { userId = /* Get the current userId */ });
        //}
    
    public IActionResult Index()
        {
            IEnumerable<Diets> objDietsList = _context.Diets;
            /*Select statement is not needed here as _context.Diets will get all the categories from table*/

            return View(objDietsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Diets obj)
        {
            if (ModelState.IsValid)
            {
                _context.Diets.Add(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Diets created successfully";
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
            var categories = _context.Diets.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(Diets obj)
        {
            if (ModelState.IsValid)
            {
                _context.Diets.Update(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Diets updated successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categories = _context.Diets.Find(id); //find if used for finding the primary key of the table
            //var categoriesFirst= _context.Diets.FirstOrDefault(u=>u.Id==id);
            //var categoriesSingle = _context.Diets.SingleOrDefault(u => u.Id == id);

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
            var obj = _context.Diets.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Diets.Remove(obj); //items input from user
            _context.SaveChanges(); //Save the items to the database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}
