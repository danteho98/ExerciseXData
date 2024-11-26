
using ExerciseXData_UserLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "User")]
    [Route("user/dashboard")]
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

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID
            var userDashboardData = await _usersService.GetUserDashboardDataAsync(userId);

            if (userDashboardData == null)
            {
                return NotFound("User data not found.");
            }

            return View(userDashboardData);
        }

        [HttpGet("diet")]
        public async Task<IActionResult> DietPlan()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dietPlan = await _usersService.GetUserDietPlanAsync(userId);

            return View(dietPlan);
        }

        [HttpPost("diet")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDietPlan(DietPlanDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _usersService.UpdateUserDietPlanAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), model);
                if (result)
                {
                    TempData["SuccessMessage"] = "Diet plan updated successfully!";
                    return RedirectToAction(nameof(DietPlan));
                }
                ModelState.AddModelError("", "Failed to update diet plan.");
            }
            return View(model);
        }

        [HttpGet("exercise")]
        public async Task<IActionResult> ExercisePlan()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercisePlan = await _usersService.GetUserExercisePlanAsync(userId);

            return View(exercisePlan);
        }

        [HttpPost("exercise")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateExercisePlan(ExercisePlanDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _usersService.UpdateUserExercisePlanAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), model);
                if (result)
                {
                    TempData["SuccessMessage"] = "Exercise plan updated successfully!";
                    return RedirectToAction(nameof(ExercisePlan));
                }
                ModelState.AddModelError("", "Failed to update exercise plan.");
            }
            return View(model);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profile = await _usersService.GetUserProfileAsync(userId);

            return View(profile);
        }

        [HttpPost("profile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _usersService.UpdateUserProfileAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), model);
                if (result)
                {
                    TempData["SuccessMessage"] = "Profile updated successfully!";
                    return RedirectToAction(nameof(Profile));
                }
                ModelState.AddModelError("", "Failed to update profile.");
            }
            return View(model);
        }

        [HttpGet("progress")]
        public async Task<IActionResult> Progress()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var progress = await _usersService.GetUserProgressAsync(userId);

            return View(progress);
        }

    }
}
    