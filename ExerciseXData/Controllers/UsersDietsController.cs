using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class UsersDietsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
