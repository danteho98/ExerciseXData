
using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ILogger<StatisticsController> _logger;

        public StatisticsController(ILogger<StatisticsController> logger)
        {
            _logger = logger;
        }
      
        public IActionResult Diets() 
        {
            return View();
        }
        public IActionResult Exercises()
        {
            return View();
        }
    }
}
