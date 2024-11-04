using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class DietsFoodsController : Controller
    {
        private readonly DietDbContext _dietContext;
        public DietsFoodsController(DietDbContext dietContext)
        {
            _dietContext = dietContext;
        }

        public IActionResult Index()
        {
            IEnumerable<DietsFoodsModel> objDietsFoodsList = _dietContext.DietsFoods;
            /*Select statement is not needed here as _dietContext.DietsFoods will get all the dietsFoods from table*/

            return View(objDietsFoodsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DietsFoodsModel obj)
        {
            if (ModelState.IsValid)
            {
                _dietContext.DietsFoods.Add(obj); //items input from user
                _dietContext.SaveChanges(); //Save the items to the database
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
            var dietsFoods = _dietContext.DietsFoods.Find(id);
            if (dietsFoods == null)
            {
                return NotFound();
            }

            return View(dietsFoods);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(DietsFoodsModel obj)
        {
            if (ModelState.IsValid)
            {
                _dietContext.DietsFoods.Update(obj); //items input from user
                _dietContext.SaveChanges(); //Save the items to the database
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
            var dietsFoods = _dietContext.DietsFoods.Find(id); //find if used for finding the primary key of the table
            //var dietsFoodsFirst= _dietContext.DietsFoods.FirstOrDefault(u=>u.Id==id);
            //var dietsFoodsSingle = _dietContext.DietsFoods.SingleOrDefault(u => u.Id == id);

            if (dietsFoods == null)
            {
                return NotFound();
            }

            return View(dietsFoods);
        }

        //POST
        [HttpPost] //ActionName can be used to name explicitly for the delete page
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dietContext.DietsFoods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dietContext.DietsFoods.Remove(obj); //items input from user
            _dietContext.SaveChanges(); //Save the items to the database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}
