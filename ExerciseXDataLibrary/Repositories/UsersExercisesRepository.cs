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
    public class UsersExercisesRepository 
    { 
        private readonly AppDbContext _context;
        public UsersExercisesRepository(AppDbContext context) => _context = context;
        public Task<List<UsersExercises>> GetByUserId(int userId) =>
            _context.UsersExercises.Where(ue => ue.U_Id == userId).ToListAsync();
    }
}
