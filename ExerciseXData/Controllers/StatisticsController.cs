using ExerciseXData.Data;
using ExerciseXData.Models;
using ExerciseXData.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Exercise()
        {
            return View();
        }
    }
}
