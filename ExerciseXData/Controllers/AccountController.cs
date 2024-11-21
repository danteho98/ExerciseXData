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
                    UserName = model.UserName,
                    Email = model.Email,
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
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
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
        public async Task<IActionResult> Login(LoginDto model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
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
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // This helper method adds model errors to the ViewData
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // Helper method to redirect to local URL or fallback to home
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        // GET: /Account/Lockout
        public IActionResult Lockout()
        {
            return View();  // This could display a message like "Your account is locked out. Please try again later."
        }

    }
}
