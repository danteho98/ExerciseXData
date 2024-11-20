using ExerciseXData.Data;

using ExerciseXData_ExerciseLibrary.Data;
using ExerciseXData_ExerciseLibrary.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseXDataLibrary.Repositories
{
    public class ExercisesRepository
    {
        private readonly ExerciseDbContext _context;

        public ExercisesRepository(ExerciseDbContext context)
        {
            _context = context;
        }

        //// Retrieve all exercises
        //public async Task<IEnumerable<ExercisesModel>> GetAllExercisesAsync()
        //{
        //    return await _context.Exercises.ToListAsync();
        //}

        //// Find a specific exercise by ID
        //public async Task<ExercisesModel> GetExerciseByIdAsync(int exerciseId)
        //{
        //    return await _context.Exercises.FindAsync(exerciseId);
        //}

        //// Add a new exercise
        //public async Task AddExerciseAsync(ExercisesModel exercise)
        //{
        //    await _context.Exercises.AddAsync(exercise);
        //    await _context.SaveChangesAsync();
        //}

        //// Update an existing exercise
        //public async Task<bool> UpdateExerciseAsync(int id, ExercisesModel exercise)
        //{
        //    var existingExercise = await _context.Exercises.FindAsync(id);
        //    if (existingExercise == null)
        //        return false;

        //    // Update properties here
        //    _context.Entry(existingExercise).CurrentValues.SetValues(exercise);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        //// Delete an exercise
        //public async Task<bool> DeleteExerciseAsync(int exerciseId)
        //{
        //    var exercise = await _context.Exercises.FindAsync(exerciseId);
        //    if (exercise != null)
        //    {
        //        _context.Exercises.Remove(exercise);
        //        await _context.SaveChangesAsync();
        //        return true; // Indicate success
        //    }
        //    return false; // Indicate failure (exercise not found)
        //}

    }
}
