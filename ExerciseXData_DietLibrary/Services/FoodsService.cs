
using ExerciseXData_DietLibrary.Data;
using ExerciseXData_DietLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseXData_DietLibrary.Services
{
    public class FoodsService
    {

        private readonly DietDbContext _dietDbContext;

        public FoodsService(DietDbContext dietDbContext)
        {
            _dietDbContext = dietDbContext;
        }

       

    }
}
