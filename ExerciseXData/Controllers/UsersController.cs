
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    //[Authorize(Roles = "User")]
    public class UsersController : Controller
    {
        public IActionResult UserDashboard()
        {
            // Code for normal user dashboard
            return View();
        }



    }
}
    