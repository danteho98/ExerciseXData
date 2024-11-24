using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ExerciseXData_UserLibrary.Models;
using ExerciseXData_UserLibrary.Services;
using ExerciseXData_UserLibrary.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExerciseXData.Controllers;
using ExerciseXData_UserLibrary.DataTransferObject;

namespace ExerciseXData_UserLibrary.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly UsersService _usersService;
        private readonly UsersRepository _usersRepository;
        private readonly UserManager<UsersModel> _userManager;
        private readonly SignInManager<UsersModel> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UsersService usersService,
            UsersRepository usersRepository,
            UserManager<UsersModel> userManager,
            SignInManager<UsersModel> signInManager,
            ILogger<AccountController> logger)
        {
            _usersService = usersService;
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        // GET: account/register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: account/register
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new UsersModel
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    
                    U_UserGender = model.Gender,
                    U_Age = model.Age,
                    U_Height_CM = model.Height,
                    U_Weight_KG = model.Weight,
                    U_Goal = model.Goal,
                    U_Lifestyle_Condition_1 = model.LifestyleCondition1,
                    U_Lifestyle_Condition_2 = model.LifestyleCondition2,
                    U_Lifestyle_Condition_3 = model.LifestyleCondition3,
                    U_Lifestyle_Condition_4 = model.LifestyleCondition4,
                    U_Lifestyle_Condition_5 = model.LifestyleCondition5
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign "User" role by default
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (!roleResult.Succeeded)
                    {
                        AddErrors(roleResult);
                        return View(model);
                    }

                    _logger.LogInformation("User created a new account with password.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("UserDashboard", "User");
                }
                AddErrors(result);
            }
            else
            {
                _logger.LogWarning("Registration failed due to invalid model state.");
            }
            return View(model);
        }

        // GET: account/login
        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: account/login
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email) ?? await _userManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    _logger.LogWarning("Login failed. User not found: {Email}", model.Email);
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    _logger.LogInformation("Login successful for user: {Email}", user.Email);

                    if (roles.Contains("Admin"))
                        return RedirectToAction("Dashboard", "Admin");
                    if (roles.Contains("User"))
                        return RedirectToAction("UserDashboard", "User");

                    return RedirectToAction("AccessDenied", "Account");
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out: {Email}", model.Email);
                    return RedirectToAction("Lockout", "Account");
                }

                _logger.LogWarning("Invalid login attempt for user: {Email}", model.Email);
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            else
            {
                _logger.LogWarning("Login failed due to invalid model state.");
            }

            return View(model);
        }

        // POST: account/logout
        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.About), "About");
        }

        // GET: account/accessdenied
        [HttpGet("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: account/lockout
        [HttpGet("lockout")]
        public IActionResult Lockout()
        {
            return View();
        }

        // Helper: Add identity errors to ModelState
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}