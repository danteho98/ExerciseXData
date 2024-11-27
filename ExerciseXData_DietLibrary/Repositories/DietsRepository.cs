

using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using ExerciseXData_SharedContracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_DietLibrary.Repositories
{
    public class DietsRepository : IDietRepository
    {
        private readonly DietDbContext _dietDbContext;

        public DietsRepository(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }


        public async Task<int> GetTotalDietsAsync()
        {
            return await _dietDbContext.Diets.CountAsync();
        }
    }
}
