using ExerciseXData.Admin;
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseXData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;
        private readonly SignInManager<UsersModel> _signInManager;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger, SignInManager<UsersModel> signInManager)
        {
            _adminService = adminService;
            _logger = logger;
            _signInManager = signInManager;
        }

        [HttpGet("admin/dashboard")]
        public async Task<IActionResult> AdminDashboard()
        {
            var dashboardData = await _adminService.GetAdminDashboardDataAsync();
            if (dashboardData == null)
            {
                return NotFound("Dashboard data not found.");
            }
            return View(dashboardData); 
        }


        // POST: admin/logout
        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Sign out the admin user
            await _signInManager.SignOutAsync();

            // Log the event
            _logger.LogInformation("Admin logged out successfully.");

            // Redirect to Home page 
            return RedirectToAction("About", "Home");
        }
    }
}

