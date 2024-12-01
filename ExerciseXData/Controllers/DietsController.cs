using Microsoft.AspNetCore.Mvc;
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;

namespace ExerciseXData.Controllers
{
    [Route("admin/diets")]
    public class DietsController : Controller
    {
        private readonly DietDbContext _dietDbContext;

        public DietsController(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

        // GET: Admin/Diets
        [HttpGet("")]
        public IActionResult Index()
        {
            List<DietsModel> dietList = _dietDbContext.Diets.ToList();
            /*Select statement is not needed here as _db.Category will get all the categories from table*/

            return View(dietList);
        }

        // GET: Admin/Diets/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost("Create")]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Create(DietsModel diet)
        {

            if (ModelState.IsValid)
            {
                _dietDbContext.Diets.Add(diet); //items input from user
                _dietDbContext.SaveChanges(); //Save the items to the database
                TempData["success"] = "Diet created successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(diet);
        }


        // GET: Admin/Diets/Edit/5
        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dietsFromDb = _dietDbContext.Diets.Find(id); //find if used for finding the primary key of the table
            //var categoryFromDbFirst= _db.Category.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Category.SingleOrDefault(u => u.Id == id);

            if (dietsFromDb == null)
            {
                return NotFound();
            }

            return View(dietsFromDb);
        }

        // POST: Admin/Diets/Edit/5
        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(DietsModel diet)
        {
            if (!_dietDbContext.Diets.Any(d => d.D_Id == diet.D_Id))
            {
                ModelState.AddModelError("", "Invalid Diet ID.");
                return View(diet);
            }

            if (ModelState.IsValid)
            {
                _dietDbContext.Diets.Update(diet); //items input from user
                _dietDbContext.SaveChanges(); //Save the items to the database
                TempData["success"] = "Diet updated successfully";
                return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
            }
            return View(diet);
        }


        // GET: Admin/Diets/Delete/5
        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dietsFromDb = _dietDbContext.Diets.Find(id); //find if used for finding the primary key of the table

            if (dietsFromDb == null)
            {
                return NotFound();
            }

            return View(dietsFromDb);
        }

        // POST: Admin/Diets/Delete/5
        [HttpPost("Delete/{id:int}")] //ActionName can be used to name explicitly for the delete page
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult DeleteSuccess(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var diet = _dietDbContext.Diets.Find(id);
            if (diet == null)
            {
                return NotFound();
            }
            _dietDbContext.Diets.Remove(diet); //items input from user
            _dietDbContext.SaveChanges(); //Save the items to the database

            TempData["success"] = "Diet deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }

    }
}
