using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}
