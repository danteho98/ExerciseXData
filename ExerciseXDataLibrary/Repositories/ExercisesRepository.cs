using ExerciseXData.Data;
using ExerciseXData.Models;
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
        private readonly AppDbContext _context;
        public async Task AddUserExerciseAsync(int userId, int exerciseId)
        {
            var userExercise = new UsersExercises
            {
                U_Id = userId,
                E_Id = exerciseId
            };

            _context.UsersExercises.Add(userExercise);
            await _context.SaveChangesAsync();
        }
    }
}
