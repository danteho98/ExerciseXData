using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ExerciseXDataLibrary.DataTransferObject;
using ExerciseXDataLibrary.Services;
using System.ComponentModel;
using static ExerciseXDataLibrary.Models.UsersModel;
using static ExerciseXDataLibrary.Models.UserGender;
using ExerciseXDataLibrary.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ExerciseXData.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsersService _userService;
        private readonly UsersRepository _usersRepository;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UsersService userService, UsersRepository usersRepository, SignInManager<IdentityUser> signInManager) // Injected UsersService
        {
            _userService = userService;
            _usersRepository = usersRepository;
            _signInManager = signInManager;
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

            // Convert dto.Gender string to Gender enum
            var gender = Enum.TryParse<Gender>(dto.Gender, out var parsedGender) ? parsedGender : Gender.PreferNotToSay;


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

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Invalid login attempt.";
                return View(loginDto);
            }

            // Find user by email or username
            var user = await _userService.FindUserByEmailOrUsernameAsync(loginDto.EmailOrUsername);
            if (user == null)
            {
                ViewData["ErrorMessage"] = "No account found with that email or username. Please register first.";
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(loginDto);
            }

            // Use SignInManager to authenticate user
            var result = await _signInManager.PasswordSignInAsync(user.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("UserDashboard");
            }
            else
            {
                ViewData["ErrorMessage"] = "Username or password is incorrect.";
                return View(loginDto);
            }
        }

        [HttpGet]
        [Authorize (Roles = "NormalUser")]
        public IActionResult UserDashboard()
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = new UserDashboardDto
                {
                    Username = User.Identity.Name  // Assuming the user is logged in
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Login");
            }

            //return View();
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
