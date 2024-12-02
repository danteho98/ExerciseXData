using ExerciseXData_UserLibrary.DataTransferObject;
using ExerciseXData_UserLibrary.Models;
using ExerciseXData_UserLibrary.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "User")]
    [Route("user/dashboard")]
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;
        private readonly UserManager<UsersModel> _userManager;
        private readonly ILogger<AdminController> _logger;
        public UsersController(UsersService usersService, UserManager<UsersModel> userManager, ILogger<AdminController> logger)
        {
            _usersService = usersService;
            _userManager = userManager;
            _logger = logger;
        }

        // Admin: View all registered users
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users); // View will list all users
        }

        // Admin: Delete a user
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
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
                Weight_KG = user.Weight_KG
                
              
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
    