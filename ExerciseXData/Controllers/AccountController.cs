using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ExerciseXData_UserLibrary.Models;
using ExerciseXData_UserLibrary.Services;
using ExerciseXData_UserLibrary.Repositories;
using ExerciseXData.Controllers;
using ExerciseXData_UserLibrary.DataTransferObject;
using System.Security.Claims;

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
        public IActionResult Login()
        {
            // Redirect authenticated users to their appropriate dashboard
            if (User.Identity.IsAuthenticated)
            {
                var roles = HttpContext.User.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("AdminDashboard", "Admin");
                }

                if (roles.Contains("User"))
                {
                    return RedirectToAction("UserDashboard", "Users");
                }
            }

            // Set cache control headers to prevent caching of the login page
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return View();
        }

        // POST: account/login
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model, string returnUrl = null)
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
                    _logger.LogInformation("Login successful for user: {Email}", user.Email);

                    // Redirect based on role
                    var roles = await _userManager.GetRolesAsync(user);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    if (roles.Contains("Admin")) 
                    {
                        return RedirectToAction("AdminDashboard", "Admin"); 
                    }
                        
                    if (roles.Contains("User")) 
                    { 
                        return RedirectToAction("UserDashboard", "Users"); 
                    }
                        
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

        // GET: account/forgotpassword
        [HttpGet("forgotpassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: account/forgotpassword
        [HttpPost("forgotpassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "No account found with this email.");
                return View();
            }

            // Fetch security questions from the database
            var questions = await _usersRepository.GetSecurityQuestionsForUserAsync(user.Id); // You need to implement this method
            return View("SecurityQuestions", new SecurityQuestionsDto { SecurityQuestions = questions, Email = email });
        }


        // POST: account/logout
        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            return RedirectToAction("About", "Home");
        }

        //private IActionResult RedirectToLocal(string returnUrl, IdentityUser user)
        //{
        //    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }

        //    if (User.IsInRole("Admin"))
        //    {
        //        return RedirectToAction("AdminDashboard", "Admin");
        //    }

        //    return RedirectToAction("UserDashboard", "Users");
        //}

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