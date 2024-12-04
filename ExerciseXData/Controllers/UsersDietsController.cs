using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using ExerciseXData_UserLibrary.Models;
using Microsoft.AspNetCore.Identity;
using ExerciseXData_SharedLibrary.Dto;

namespace ExerciseXData.Controllers
{
    public class UsersDietsController : Controller
    {
        private readonly DietDbContext _dietDbContext;
        private readonly UserManager<UsersModel> _userManager;

        public UsersDietsController(DietDbContext dietDbContext, UserManager<UsersModel> userManager)
        {
            _dietDbContext = dietDbContext;
            _userManager = userManager;
        }

        // GET: UsersDiets
        public async Task<IActionResult> Index()
        {
            var usersDiets = await _dietDbContext.UsersDiets
                .Include(ud => ud.User)
                .Include(ud => ud.Diet)
                .Select(ud => new UsersDietsIndexDto
                {
                    UD_Id = ud.UD_Id,
                    UserName = ud.User.UserName,
                    DietName = ud.Diet.D_Name,
                    CustomDietName = ud.CustomDietName,
                    UD_ServingSize = ud.UD_ServingSize,
                    UD_Frequency = ud.UD_Frequency,
                    UD_TotalCalories = ud.UD_TotalCalaroies,
                    StartDate = ud.StartDate,
                    EndDate = ud.EndDate,
                    IsCompleted = ud.IsCompleted,
                    UD_Modified_Date = ud.UD_Modified_Date
                })
                .ToListAsync();

            return View(usersDiets);
        }

        // GET: UsersDiets/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = await _userManager.Users.ToListAsync(); // For user selection
            ViewBag.Diets = await _dietDbContext.Diets.ToListAsync(); // For diet selection
            return View();
        }

        // POST: UsersDiets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersDietsModel model)
        {
            if (ModelState.IsValid)
            {
                _dietDbContext.UsersDiets.Add(model);
                await _dietDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Users = await _userManager.Users.ToListAsync();
            ViewBag.Diets = await _dietDbContext.Diets.ToListAsync();
            return View(model);
        }

        // GET: UsersDiets/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usersDiet = await _dietDbContext.UsersDiets
                .Include(ud => ud.User)
                .Include(ud => ud.Diet)
                .FirstOrDefaultAsync(ud => ud.UD_Id == id);

            if (usersDiet == null)
                return NotFound();

            ViewBag.Users = await _userManager.Users.ToListAsync();
            ViewBag.Diets = await _dietDbContext.Diets.ToListAsync();
            return View(usersDiet);
        }

        // POST: UsersDiets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsersDietsModel model)
        {
            if (id != model.UD_Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _dietDbContext.UsersDiets.Update(model);
                    await _dietDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersDietExists(model.UD_Id))
                        return NotFound();

                    throw;
                }
            }

            ViewBag.Users = await _userManager.Users.ToListAsync();
            ViewBag.Diets = await _dietDbContext.Diets.ToListAsync();
            return View(model);
        }

        // GET: UsersDiets/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var usersDiet = await _dietDbContext.UsersDiets
                .Include(ud => ud.User)
                .Include(ud => ud.Diet)
                .FirstOrDefaultAsync(ud => ud.UD_Id == id);

            if (usersDiet == null)
                return NotFound();

            return View(usersDiet);
        }

        // POST: UsersDiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersDiet = await _dietDbContext.UsersDiets.FindAsync(id);
            if (usersDiet != null)
            {
                _dietDbContext.UsersDiets.Remove(usersDiet);
                await _dietDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UsersDietExists(int id)
        {
            return _dietDbContext.UsersDiets.Any(ud => ud.UD_Id == id);
        }
    }
}
