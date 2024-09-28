using ExerciseXData.Data;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData.Controllers
{
    public class ExercisesController : Controller
    {

        private readonly AppDbContext _context;
        public ExercisesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Exercises> objExercisesList = _context.Exercises;
            /*Select statement is not needed here as _context.Exercises will get all the exercises from table*/

            return View(objExercisesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Exercises obj)
        {
            if (ModelState.IsValid)
            {
                _context.Exercises.Add(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Exercises created successfully";
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
            var exercises = _context.Exercises.Find(id);
            if (exercises == null)
            {
                return NotFound();
            }

            return View(exercises);
        }

        //post
        [HttpPost]
        //[ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(Exercises obj)
        {
            if (ModelState.IsValid)
            {
                _context.Exercises.Update(obj); //items input from user
                _context.SaveChanges(); //Save the items to the database
                TempData["success"] = "Exercises updated successfully";
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
            var exercises = _context.Exercises.Find(id); //find if used for finding the primary key of the table
            //var exercisesFirst= _context.Exercises.FirstOrDefault(u=>u.Id==id);
            //var exercisesSingle = _context.Exercises.SingleOrDefault(u => u.Id == id);

            if (exercises == null)
            {
                return NotFound();
            }

            return View(exercises);
        }

        //POST
        [HttpPost] //ActionName can be used to name explicitly for the delete page
        //[ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Exercises.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Exercises.Remove(obj); //items input from user
            _context.SaveChanges(); //Save the items to the database
            TempData["success"] = "Exercises deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}