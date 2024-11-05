
using ExerciseXData.Data;
using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    public class StatisticsController : Controller
    {
        
        public IActionResult Diets() 
        {
            var chartData = new List<int> { 10, 20, 30, 40 };  // Sample data
            ViewBag.ChartData = chartData;
           
            return View();
        }
        public IActionResult Exercises()
        {
            var chartData = new List<int> { 10, 20, 30, 40 };  // Sample data
            ViewBag.ChartData = chartData;
            return View();
        }
    }
}
