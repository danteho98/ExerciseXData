

using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ExerciseXData_DietLibrary.Repositories
{
    public class DietsFoodsRepository
    {
        private readonly DietDbContext _dietDbContext;
        public DietsFoodsRepository(DietDbContext dietDbContext) 
        {
            _dietDbContext = dietDbContext; 
        }

        
    }
}
