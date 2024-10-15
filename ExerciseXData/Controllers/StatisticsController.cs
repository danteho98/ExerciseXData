
using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Diet() 
        {
            return View();
        }
        public IActionResult Exercises()
        {
            return View();
        }
    }
}
