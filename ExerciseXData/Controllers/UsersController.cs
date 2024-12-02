using ExerciseXData_UserLibrary.DataTransferObject;
using ExerciseXData_UserLibrary.Models;
using ExerciseXData_UserLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "User")]
    [Route("user/dashboard")]
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;
        private readonly ILogger<UsersController> _logger;
        private readonly SignInManager<UsersModel> _signInManager;

        public UsersController(UsersService usersService, ILogger<UsersController> logger, SignInManager<UsersModel> signInManager)
        {
            _usersService = usersService;
            _logger = logger;
            _signInManager = signInManager;
        }


        [Authorize(Roles = "User")]
        public async Task<IActionResult> UserDashboard()
        {
            var emailOrUsername = User.Identity.Name; 
            var user = await _usersService.FindUserByEmailOrUsernameAsync(emailOrUsername);

            
            var model = new UserDashboardDto
            {
                Username = user.Username,
                Email = user.Email,
                Age = user.Age,
                Height_CM = user.Height_CM,
                Weight_KG = user.Weight_KG,
                Goal = user.Goal,
                Lifestyle_Condition_1 = user.Lifestyle_Condition_1,
                Lifestyle_Condition_2 = user.Lifestyle_Condition_2,
                Lifestyle_Condition_3 = user.Lifestyle_Condition_3,
                Lifestyle_Condition_4 = user.Lifestyle_Condition_4,
                Lifestyle_Condition_5 = user.Lifestyle_Condition_5
               
            };

            return View(model);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Sign out the user and clear authentication cookies
            await _signInManager.SignOutAsync();

            // Clear session data if you're using session storage
            HttpContext.Session.Clear();

            _logger.LogInformation("Admin logged out successfully.");

            return RedirectToAction("About", "Home"); // Redirect to the admin login page or other appropriate page
        }


    }
}
    