using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ExerciseXDataLibrary.DataTransferObject;
using ExerciseXDataLibrary.Services;
using System.ComponentModel;

namespace ExerciseXData.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsersService _userService;

        public AccountController(UsersService userService) // Injected UsersService
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents CSRF attacks
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto); // Return the view with validation errors if model state is invalid
            }

            var result = await _userService.RegisterUserAsync(
                dto.Email,
                dto.UserName,
                dto.Password,
                dto.Gender,
                dto.Age,
                dto.Height,
                dto.Weight,
                dto.Goal,
                dto.Lifestyle_Condition_1, 
                dto.Lifestyle_Condition_2, 
                dto.Lifestyle_Condition_3,
                dto.Lifestyle_Condition_4,
                dto.Lifestyle_Condition_5
            );

            if (result)
            {
                // Redirect to a confirmation page or login page after successful registration
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Registration failed. Please try again.");
            return View(dto); // Return to the view with an error message if registration fails
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


    }
}
