using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExerciseXData.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        public IActionResult PersonalStats()
        {
           

            return View();
        }

    }
}
