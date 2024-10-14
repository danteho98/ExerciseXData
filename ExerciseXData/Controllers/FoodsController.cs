using ExerciseXData.Data;
using ExerciseXData.Interfaces;
using ExerciseXData.Models;
using Microsoft.AspNetCore.Mvc;

namespace foodXData.Controllers
{
    public class FoodController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Statistics()
        {
            return View();
        }
    }
}