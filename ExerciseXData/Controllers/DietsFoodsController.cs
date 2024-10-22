using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class DietsFoodsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
