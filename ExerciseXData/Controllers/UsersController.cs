

using ExerciseXData_UserLibrary.Services;

using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    //[Authorize(Roles = "User")]
    //[Route("user/dashboard")]
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        public IActionResult UserDashboard()
        {
            // Code for normal user dashboard
            return View();
        }

        

    }
}
    