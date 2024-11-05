﻿using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXDataLibrary.Data;
using ExerciseXDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace foodXData.Controllers
{
    public class FoodsController : Controller
    {
        private readonly DietDbContext _dietContext;
        public FoodsController(DietDbContext dietContext)
        {
            _dietContext = dietContext;
        }

        public IActionResult Index()
        {
            IEnumerable<FoodsModel> objFoodsList = _dietContext.Foods;
            /*Select statement is not needed here as _dietContext.Foods will get all the categories from table*/

            return View(objFoodsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FoodsModel obj)
        {
            if (ModelState.IsValid)
            {
                _dietContext.Foods.Add(obj); //items input from user
                _dietContext.SaveChanges(); //Save the items to the database
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
            var categories = _dietContext.Foods.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken] //helps to prevent cross site request forgery attacks
        public IActionResult Edit(FoodsModel obj)
        {
            if (ModelState.IsValid)
            {
                _dietContext.Foods.Update(obj); //items input from user
                _dietContext.SaveChanges(); //Save the items to the database
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
            var categories = _dietContext.Foods.Find(id); //find if used for finding the primary key of the table
            //var categoriesFirst= _dietContext.Foods.FirstOrDefault(u=>u.Id==id);
            //var categoriesSingle = _dietContext.Foods.SingleOrDefault(u => u.Id == id);

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
            var obj = _dietContext.Foods.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dietContext.Foods.Remove(obj); //items input from user
            _dietContext.SaveChanges(); //Save the items to the database
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); //redirect to the Index(), can also be used to redirect to other controllers such as ("Index", "Create")
        }
    }
}