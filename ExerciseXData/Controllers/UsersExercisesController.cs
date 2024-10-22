using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class UsersExercisesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
