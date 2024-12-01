
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_DietLibrary.Services
{
    public class DietsService
    {
        private readonly DietDbContext _dietDbContext;

        public DietsService(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

      

    }
}
