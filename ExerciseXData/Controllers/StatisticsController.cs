
using ExerciseXData.Data;
using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    public class StatisticsController : Controller
    {
        //private readonly AppDbContext _context;
        //public StatisticsController(AppDbContext context)
        //{
        //    _context = context;
        //}


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
