using ExerciseXData_UserLibrary.DataTransferObject;
using ExerciseXData_UserLibrary.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "User")]
    [Route("user/dashboard")]
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;
        private readonly ILogger<AdminController> _logger;
        public UsersController(UsersService usersService, ILogger<AdminController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }


        [Authorize(Roles = "User")]
        [HttpGet("user/dashboard")]
        public async Task<IActionResult> UserDashboard()
        {
            var emailOrUsername = User.Identity.Name; // Ensure this is correct
            var user = await _usersService.FindUserByEmailOrUsernameAsync(emailOrUsername);

            //var user = await _usersService.FindUserByEmailOrUsernameAsync(User.Identity.Name);
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
                //ExercisePlans = user.ExercisePlans.Select(ep => new ExercisePlanDto
                //{
                //    Name = ep.Name,

                //    StartDate = ep.StartDate,
                //    EndDate = ep.EndDate
                //}).ToList(),
                //DietPlans = user.DietPlans.Select(dp => new DietPlanDto
                //{
                //    Name = dp.Name,
                //    Calories = dp.Calories,
                //    StartDate = dp.StartDate,
                //    EndDate = dp.EndDate
                //}).ToList()
            };

            return View(model);
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _logger.LogInformation("User logged out successfully.");
            return RedirectToAction("About", "Home"); // Redirect to the admin login page or other appropriate page
        }

    }
}
    