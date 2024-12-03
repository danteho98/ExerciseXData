using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseXData_DietLibrary.Models;
using ExerciseXData_UserLibrary.Data;
using ExerciseXData_DietLibrary.Data;

namespace ExerciseXData.Controllers
{
    public class UsersDietsController : Controller
    {
        private readonly DietDbContext _dietDbContext;
        private readonly UserDbContext _userDbContext;

        public UsersDietsController(DietDbContext dietDbContext, UserDbContext userDbContext)
        {
            _dietDbContext = dietDbContext;
            _userDbContext = userDbContext;
        }

        // GET: UsersDiets
        public async Task<IActionResult> Index()
        {
            //var usersDiets = await _userDbContext.UsersDiets
            //    .Include(ud => ud.Users)
            //    .Include(ud => ud.Diets)
            //    .ToListAsync();
            return View();
        }

        // GET: UsersDiets/Create
        public IActionResult Create()
        {
            //ViewData["Users"] = await _context.Users.ToListAsync();
            //ViewData["Diets"] = await _context.Diets.ToListAsync();
            return View();
        }

        // POST: UsersDiets/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create()
        //{
            //if (ModelState.IsValid)
            //{
            //    // Avoid duplicate entries in the junction table
            //    var exists = await _context.UsersDiets.AnyAsync(ud =>
            //        ud.U_Id == usersDietsModel.U_Id && ud.D_Id == usersDietsModel.D_Id);

            //    if (!exists)
            //    {
            //        _context.Add(usersDietsModel);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }

            //    ModelState.AddModelError("", "This user is already associated with the selected diet.");
            //}

            //ViewData["Users"] = await _context.Users.ToListAsync();
            //ViewData["Diets"] = await _context.Diets.ToListAsync();
        //    return View();
        //}

        // GET: UsersDiets/Edit/5
        public IActionResult Edit()
        {
            //if (id == null)
            //    return NotFound();

            //var usersDiet = await _context.UsersDiets
            //    .Include(ud => ud.Users)
            //    .Include(ud => ud.Diets)
            //    .FirstOrDefaultAsync(ud => ud.D_Id == id);

            //if (usersDiet == null)
            //    return NotFound();

            //ViewData["Users"] = await _context.Users.ToListAsync();
            //ViewData["Diets"] = await _context.Diets.ToListAsync();

            return View();
        }

        // POST: UsersDiets/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit()
        //{
            //if (id != usersDietsModel.D_Id)
            //    return NotFound();

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(usersDietsModel);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!UsersDietsExists(usersDietsModel.D_Id))
            //            return NotFound();
            //        else
            //            throw;
            //    }
            //    return RedirectToAction(nameof(Index));
            //}

            //ViewData["Users"] = await _context.Users.ToListAsync();
            //ViewData["Diets"] = await _context.Diets.ToListAsync();
        //    return View();
        //}

        // GET: UsersDiets/Delete/5
        public IActionResult Delete()
        {
            //if (id == null)
            //    return NotFound();

            //var usersDiet = await _context.UsersDiets
            //    .Include(ud => ud.Users)
            //    .Include(ud => ud.Diets)
            //    .FirstOrDefaultAsync(ud => ud.D_Id == id);

            //if (usersDiet == null)
            //    return NotFound();

            return View();
        }

        //// POST: UsersDiets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var usersDiet = await _context.UsersDiets.FindAsync(id);
        //    if (usersDiet != null)
        //    {
        //        _context.UsersDiets.Remove(usersDiet);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UsersDietsExists(int id)
        //{
        //    return _context.UsersDiets.Any(e => e.D_Id == id);
        //}
    }
}
