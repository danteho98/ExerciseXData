using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExerciseXData.Controllers
{
    [Authorize (Roles = "User,Admin")]
    public class UsersController : Controller
    {
        public IActionResult UserDashboard()
        {
            return View(); // User-specific dashboard
        }
    }
}
